using System;
using System.Collections.Generic;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        Guid Create(string description);
        TEntity Get(Guid code);
        IEnumerable<TEntity> Get();
        int GetPageCount(int pageSize);
        void Update(TEntity productEntity);
        void Remove(Guid code);
    }
}