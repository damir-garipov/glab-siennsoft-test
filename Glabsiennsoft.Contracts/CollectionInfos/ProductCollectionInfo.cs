using System.Collections.Generic;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.CollectionInfos
{
    public class ProductCollectionInfo : IEntityCollectionInfo<ProductWithDescription>
    {
        public int PageCount { get; set; }
        public IEnumerable<ProductWithDescription> Entities { get; set; }
        public int Count { get; set; }
    }
}