using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.MIgrate;
using Glabsiennsoft.Orm;
using NUnit.Framework;

namespace Glabsiennsoft.Tests
{
    [TestFixture]
    public class MigrateTest
    {
        private IGlobalSettings _globalSettings;
        private CommonDb _commonDb;

        [SetUp]
        public void SetupTest()
        {
            _globalSettings = new GlobalSettings();
            _commonDb = new CommonDb(_globalSettings);
            var migrater = new Migrator(_commonDb, _globalSettings);
            migrater.Up();
        }

        [Test]
        public void CheckMigrationExists()
        {
            var migrations = _commonDb.Query<string>("select name from __Migrations").ToList();
            foreach (var migrationName in migrations)
            {
                Console.WriteLine(migrationName);
            }
            Assert.That(migrations.Count > 0);
        }

        [TearDown]
        public void TearDown()
        {
            _commonDb.ExecuteNonQuery("drop database glabsiennsofttestdb");
        }
    }

    public class GlobalSettings: IGlobalSettings
    {
        public string MigrationAssemblyName => "Glabsiennsoft.MIgrate";

        public string DefaultConnectionString =>
            "Server=(local);Database=glabsiennsofttestdb;Integrated Security=True;MultipleActiveResultSets=true";
    }
}
