using System;
using System.Collections.Generic;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.Repositories
{
    public interface IProductRepository
    {
        Guid Create(Product product);
        Product Get(Guid code);
        IEnumerable<Product> Get();
        ProductCollectionInfo Get(int pageNumber, int pageSize);
        ProductCollectionInfo GetAvailableProducts(int pageNumber, int pageSize);
        ProductCollectionInfo GetByFilterProducts(int pageNumber, int pageSize, Guid? type, Guid? unit, IEnumerable<Guid> categories);
        ProductInfo GetProductInfo(Guid code);
        void Update(Product product);
        void Remove(Guid code);
    }
}