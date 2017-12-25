using System;
using System.Collections.Generic;
using System.Text;

namespace Glabsiennsoft.Contracts.DataModel
{
    public class Product: Entity
    {
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public ProductType Type { get; set; }
        public ProductUnit Unit { get; set; }
    }
}
