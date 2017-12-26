using System;
using System.Collections.Generic;
using System.Text;

namespace Glabsiennsoft.Contracts.Common.MIgrations
{
    public abstract class Migration
    {
        public List<string> Queries = new List<string>();

        public void Sql(string query)
        {
            Queries.Add(query);
        }

        public abstract void Up();

        public abstract void Down();
    }
}
