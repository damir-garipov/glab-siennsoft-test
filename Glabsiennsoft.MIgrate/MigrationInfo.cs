using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate
{
    internal class MigrationInfo
    {
        public MigrationInfo()
        {
        }

        public MigrationInfo(Migration migration)
        {
            Migration = migration;
            Attribute = migration.GetType().GetCustomAttribute<MigrationAttribute>();
            Name = migration.GetType().Name;
        }

        public string Name { get; set; }
        public MigrationAttribute Attribute { get; set; }
        public Migration Migration { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
