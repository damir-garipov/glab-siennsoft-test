using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

namespace Glabsiennsoft.Contracts.Common
{
    public interface ICommonDb
    {
        string GetConnectionString();
        IEnumerable<T> Query<T>(string query, object parameters = null);
        T ExecuteScalar<T>(string query, object parameters = null);
        int ExecuteNonQuery(string query, object parameters = null);
        void CreateDatabaseIfNotExists();
        void GetPageCount(int pageSize, string query, IEntityCollectionInfo collectionInfo);
    }
}