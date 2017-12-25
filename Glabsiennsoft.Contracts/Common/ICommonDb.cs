using System.Collections.Generic;

namespace Glabsiennsoft.Contracts.Common
{
    public interface ICommonDb
    {
        IEnumerable<T> Query<T>(string query, SqlParameter[] parameters);
        IEnumerable<T> Query<T>(string query, object parameters);

        int ExecuteNonQuery(string query, SqlParameter[] parameters);
        int ExecuteNonQuery(string query, object parameters);
    }
}