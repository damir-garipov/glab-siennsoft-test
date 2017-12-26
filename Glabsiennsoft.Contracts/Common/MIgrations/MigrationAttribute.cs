using System;
using System.Collections.Generic;
using System.Text;

namespace Glabsiennsoft.Contracts.Common.MIgrations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MigrationAttribute: Attribute
    {
        public string Description { get; }

        public MigrationAttribute(string description)
        {
            Description = description;
        }
    }
}
