using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate
{
    class MigrationCollection: IMigrationCollection
    {
        private readonly List<Migration> _migrations = new List<Migration>();

        public MigrationCollection(Assembly migrationAssembly)
        {
            var migrations = migrationAssembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(Migration))
                .Select(t => (Migration) Activator.CreateInstance(t));

            _migrations.AddRange(migrations);
        }

        public IEnumerator<Migration> GetEnumerator()
        {
            return _migrations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
