using System;
using System.Collections.Generic;
using System.Linq;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Glabsiennsoft.DataRepository.Exceptions;

namespace Glabsiennsoft.DataRepository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ICommonDb _commonDb;

        public UnitRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public Guid Create(string description)
        {
            try
            {
                var productUnit = new ProductUnit {Description = description};
                _commonDb.ExecuteNonQuery("insert into units(code, description) values(@code, @description)",
                    productUnit);

                return productUnit.Code;
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException("Unit create error!", e);
            }
        }

        public ProductUnit Get(Guid code)
        {
            try
            {
                return _commonDb.Query<ProductUnit>("select * from units where code = @code", new {code}).First();
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Unit with code {code} get error!", e);
            }
        }

        public IEnumerable<ProductUnit> Get()
        {
            try
            {
                return _commonDb.Query<ProductUnit>("select * from units");
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Units get error!", e);
            }
        }

        public UnitCollectionInfo Get(int pageNumber, int pageSize)
        {
            try
            {
                var collectionInfo = new UnitCollectionInfo();
                collectionInfo.Entities = _commonDb.Query<ProductUnit>($"select * from units order by code offset {pageNumber*pageSize-pageSize} rows fetch next {pageSize} rows only");

                _commonDb.GetPageCount(pageSize, "select count(1) from units", collectionInfo);
                return collectionInfo;

            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Units get error!", e);
            }
        }

        public int GetPageCount(int pageSize)
        {
            try
            {
                var count = _commonDb.ExecuteScalar<int>($"select count(1) from units");
                return count/pageSize+count%pageSize;
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Units get page size error!", e);
            }
        }

        public void Update(ProductUnit productUnit)
        {
            try
            {
                _commonDb.ExecuteNonQuery("update units set description = @description where code = @code", productUnit);
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Unit {productUnit} update error!", e);
            }
        }

        public void Remove(Guid code)
        {
            try
            {
                _commonDb.ExecuteNonQuery("delete units where code = @code", new {code});
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Unit with {code} delete error!", e);
            }
        }
    }
}
