using System;

namespace Glabsiennsoft.Contracts.DataModel
{
    public abstract class Entity
    {
        protected Entity()
        {
            Code = Guid.NewGuid();
        }

        public Guid Code { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{{ \"ProductUnit\": {{\"Code\" : \"{Code}\", \"Description\" : {Description}}} }}";
        }
    }
}