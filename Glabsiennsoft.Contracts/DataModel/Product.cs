using System;
using System.Collections.Generic;
using System.Text;

namespace Glabsiennsoft.Contracts.DataModel
{
    public class Product: Entity
    {
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public ProductType Type { get; set; }
        public ProductUnit Unit { get; set; }
        public Guid CodeType { get; set; }
        public Guid CodeUnit { get; set; }
    }

    public class ProductWithDescription : Entity
    {
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public ProductType Type { get; set; }
        public ProductUnit Unit { get; set; }
        public Guid CodeType { get; set; }
        public Guid CodeUnit { get; set; }
        public string TypeDescription { get; set; }
        public string UnitDescription { get; set; }
    }
}
