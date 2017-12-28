using System;

namespace Glabsiennsoft.DataRepository.Exceptions
{
    public class ProductTypeOperationException : EntityOperationException
    {
        public ProductTypeOperationException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}