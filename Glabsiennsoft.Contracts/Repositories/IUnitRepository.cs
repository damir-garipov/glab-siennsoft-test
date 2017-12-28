using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;

namespace Glabsiennsoft.Contracts.Repositories
{

    public interface IUnitRepository : IRepository<ProductUnit>
    {
        UnitCollectionInfo Get(int pageNumber, int pageSize);
    }
}