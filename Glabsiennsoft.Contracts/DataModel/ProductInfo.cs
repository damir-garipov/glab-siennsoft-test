using System;
using System.Globalization;
using Glabsiennsoft.Contracts.Repositories;

namespace Glabsiennsoft.Contracts.DataModel
{
    public class ProductInfo
    {
        public ProductInfo(ProductInfoRaw raw, ITypeRepository typeRepository, IUnitRepository unitRepository)
        {
            ProductDescription = raw.ProductDescription;
            Price = raw.Price;
            IsAvailable = raw.IsAvailable;
            DeliveryDate = raw.DeliveryDate;
            CodeType = raw.CodeType;
            CodeUnit = raw.CodeUnit;
            Type = typeRepository.Get(CodeType)?.Description;
            Unit = unitRepository.Get(CodeUnit)?.Description;
            CategoryCount = raw.CategoryCount;
            Code = raw.Code.ToString();
        }

        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string PricePoland => Price.ToString("C", new CultureInfo("pl-PL"));
        public bool IsAvailable { get; set; }
        public string Available => IsAvailable ? "Yes = „Available”" : "No = „Unavailable”";
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateFormat => DeliveryDate.ToString("dd.MM.yyyy");
        public int    CategoryCount { get; set; }
        public Guid CodeType { get; set; }
        public Guid CodeUnit { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Code { get; set; }
    }

    public class ProductInfoRaw
    {
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public Guid Code { set; get; }
        public bool IsAvailable { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Guid CodeType { get; set; }
        public Guid CodeUnit { get; set; }
        public int CategoryCount { get; set; }
    }
}