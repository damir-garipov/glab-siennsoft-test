using System;
using System.Collections.Generic;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.DataRepository.Exceptions;

namespace Glabsiennsoft.DataRepository
{
    public class UnitsRepository
    {
        private readonly ICommonDb _commonDb;

        public UnitsRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public Guid Create(string description)
        {
            try
            {
                var productUnit = new ProductUnit {Description = description};
                _commonDb.ExecuteNonQuery("insert into productunits(code, description) values(@code, @description)",
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
                return _commonDb.ExecuteScalar<ProductUnit>("select * from productunits where code = @code", new {code});
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
                return _commonDb.Query<ProductUnit>("select * from productunits");
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Units get error!", e);
            }
        }

        public IEnumerable<ProductUnit> Get(int pageNumber, int pageSize)
        {
            try
            {
                return _commonDb.Query<ProductUnit>($"select * from productunits order by code offset {pageNumber*pageSize-pageSize} rows fetch next {pageSize}");
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
                var count = _commonDb.ExecuteScalar<int>($"select count(1) from productunits");
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
                _commonDb.ExecuteNonQuery("update productunits set description = @description where code = @code", productUnit);
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
                _commonDb.ExecuteNonQuery("delete productunits where code = @code", new {code});
            }
            catch (Exception e)
            {
                throw new ProductUnitOperationException($"Unit with {code} delete error!", e);
            }
        }
    }
}
