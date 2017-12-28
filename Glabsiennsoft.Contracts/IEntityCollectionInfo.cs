using System.Collections.Generic;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts
{
    public interface IEntityCollectionInfo
    {
        int PageCount { get; set; }
        int Count { get; set; }
    }

    public interface IEntityCollectionInfo<TEntity> : IEntityCollectionInfo where TEntity: Entity
    {
        IEnumerable<TEntity> Entities { get; set; }
    }
}