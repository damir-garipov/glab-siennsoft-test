using System;

namespace Glabsiennsoft.DataRepository.Exceptions
{
    public class CategoryOperationException : EntityOperationException
    {
        public CategoryOperationException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}