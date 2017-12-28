using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glabsiennsoft.WebApi.Models
{
    public class ProductFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Guid? Type { get; set; }
        public Guid? Unit { get; set; }
        public IEnumerable<Guid> Categories { get; set; }
    }
}
