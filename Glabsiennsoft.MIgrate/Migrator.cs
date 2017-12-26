using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate
{
    public class Migrator: IMigrator
    {
        private readonly ICommonDb _commonDb;
        private readonly IMigrationCollection _migrationCollection;

        public Migrator(ICommonDb commonDb, IGlobalSettings settings)
        {
            _commonDb = commonDb;
            var assemblyName = new AssemblyName(settings.MigrationAssemblyName);
            var migrationAssembly = Assembly.Load(assemblyName);
            _migrationCollection = new MigrationCollection(migrationAssembly);
        }

        public void Up()
        {
            _commonDb.CreateDatabaseIfNotExists();
            CreateTableIfNotExists();

            foreach (var migration in _migrationCollection)
            {
                var migrationInfo = new MigrationInfo(migration);
                Up(migrationInfo);
                Thread.Sleep(1);
            }
        }

        public void Down(string name)
        {
            var migrationModels =
                _commonDb.Query<MigrationModel>(
                    "select * from __Migrations where date >= (select date from __Migrations where name = @name)", new {name});

            var migrations = migrationModels.Select(mm =>
            {
                var migration = _migrationCollection.First(m => m.GetType().Name == mm.Name);
                return new MigrationInfo
                {
                    Attribute = migration.GetType().GetCustomAttribute<MigrationAttribute>(),
                    Name = mm.Name,
                    Migration = migration,
                    CreatedDate = mm.Date
                };
            }).OrderByDescending(mm => mm.CreatedDate);

            foreach (var migrationInfo in migrations)
            {
                Down(migrationInfo);
            }
        }

        private void CreateTableIfNotExists()
        {
            if (TableExists())
                return;

            CreateMigrationTable();
        }

        private void Down(MigrationInfo migrationInfo)
        {
            migrationInfo.Migration.Down();
            foreach (var query in migrationInfo.Migration.Queries)
            {
                _commonDb.ExecuteNonQuery(query);
            }

            _commonDb.ExecuteNonQuery("delete from __Migrations where name = @name", new {migrationInfo.Name});
        }

        private void Up(MigrationInfo migrationInfo)
        {
            if (MigrateExists(migrationInfo.Name))
                return;

            migrationInfo.Migration.Up();
            foreach (var query in migrationInfo.Migration.Queries)
            {
                _commonDb.ExecuteNonQuery(query);
            }

            _commonDb.ExecuteNonQuery("insert into __Migrations(name, description) values(@name, @description)",
                new {migrationInfo.Name, migrationInfo.Attribute.Description});
        }

        private bool MigrateExists(string migrateName)
        {
            return _commonDb.ExecuteScalar<bool>("select top 1 cast(isExist as bit) from (select 1 as isExist from __Migrations where name = @name union all select 0) s1", new {name = migrateName});
        }

        private void CreateMigrationTable()
        {
            var query = "create table __Migrations (name nvarchar(50) not null primary key, description nvarchar(max), date datetime2 not null default getdate())";
            _commonDb.ExecuteNonQuery(query);
        }

        private bool TableExists()
        {
            return _commonDb.ExecuteScalar<bool>(
                "select top 1 cast(isExist as bit) from (select 1 isExist from INFORMATION_SCHEMA.TABLES where TABLE_NAME = '__Migrations' and TABLE_SCHEMA = 'dbo' union all select 0)s1");
        }
    }

    public class MigrationModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
