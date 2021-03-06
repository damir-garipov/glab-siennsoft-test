﻿using System.Collections.Generic;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.CollectionInfos
{
    public class TypeCollectionInfo: IEntityCollectionInfo<ProductType>
    {
        public int PageCount { get; set; }
        public IEnumerable<ProductType> Entities { get; set; }
        public int Count { get; set; }
    }
}