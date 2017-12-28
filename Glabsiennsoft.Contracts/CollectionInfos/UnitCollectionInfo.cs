using System.Collections.Generic;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.CollectionInfos
{
    public class UnitCollectionInfo: IEntityCollectionInfo<ProductUnit>
    {
        public int PageCount { get; set; }
        public IEnumerable<ProductUnit> Entities { get; set; }
        public int Count { get; set; }
    }
}
