using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.Repositories
{
    public interface ITypeRepository : IRepository<ProductType>
    {
        TypeCollectionInfo Get(int pageNumber, int pageSize);
    }
}