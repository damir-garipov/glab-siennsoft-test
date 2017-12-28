using System;

namespace Glabsiennsoft.DataRepository.Exceptions
{
    public class EntityOperationException : Exception
    {
        public EntityOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class ProductUnitOperationException : EntityOperationException
    {
        public ProductUnitOperationException(string message, System.Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}