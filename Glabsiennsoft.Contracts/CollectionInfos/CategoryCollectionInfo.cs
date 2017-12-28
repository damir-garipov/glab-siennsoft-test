using System.Collections.Generic;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.CollectionInfos
{
    public class CategoryCollectionInfo: IEntityCollectionInfo<ProductCategory>
    {
        public int PageCount { get; set; }
        public IEnumerable<ProductCategory> Entities { get; set; }
        public int Count { get; set; }
    }
}