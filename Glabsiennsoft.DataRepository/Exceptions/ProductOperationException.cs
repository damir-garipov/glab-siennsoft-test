using System;

namespace Glabsiennsoft.DataRepository.Exceptions
{
    public class ProductOperationException : EntityOperationException
    {
        public ProductOperationException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}