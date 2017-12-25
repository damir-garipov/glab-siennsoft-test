using System;

namespace Glabsiennsoft.Contracts.DataModel
{
    public abstract class Entity
    {
        public Guid Code { get; set; }
        public string Description { get; set; }
    }
}