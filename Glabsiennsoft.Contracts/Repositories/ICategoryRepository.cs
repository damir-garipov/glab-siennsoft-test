using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<ProductCategory>
    {
        CategoryCollectionInfo Get(int pageNumber, int pageSize);
    }
}