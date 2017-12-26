using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using Dapper;
using Glabsiennsoft.Contracts.Common;

namespace Glabsiennsoft.Orm
{
    public class CommonDb: ICommonDb
    {
        private readonly IGlobalSettings _settings;

        public CommonDb(IGlobalSettings settings)
        {
            _settings = settings;
        }

        public string GetConnectionString()
        {
            return _settings.DefaultConnectionString;
        }

        public IEnumerable<T> Query<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(query, parameters);
            }
        }

        public T ExecuteScalar<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return connection.ExecuteScalar<T>(query, parameters);
            }
        }

        public int ExecuteNonQuery(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(query, parameters);
            }
        }

        public void CreateDatabaseIfNotExists()
        {
            var connectionString = GetConnectionString();
            var dbName = GetDbName(connectionString);

            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = "master";

            if (DatabaseExists(dbName, builder.ToString()))
                return;

            using (var connection = new SqlConnection(builder.ToString()))
            {
                connection.Execute($"create database {dbName}");
            }
        }

        private string GetDbName(string connection)
        {
            var dbName = Regex.Match(connection, @"database=(?<dbName>[\w]+);|initial catalog=(?<dbName>[\w]+);", RegexOptions.IgnoreCase).Groups["dbName"].Value;
            return dbName;
        }

        private bool DatabaseExists(string dbName, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return connection.ExecuteScalar<bool>(
                        "select top 1 cast(isExist as bit) from (select 1 isExist from (select id from (select DB_ID(@dbName) id) s where id is not null)s1 union all select 0)s2",
                        new {dbName});
                }
                finally
                {
                    connection.Close();
                }
            }
//            return ExecuteScalar<bool>("select top 1 cast(isExist as bit) from (select 1 isExist from (select id from (select DB_ID(N@dbName) id) s where id is not null)s1 union all select 0)s2", new { dbName });
        }
    }
}
