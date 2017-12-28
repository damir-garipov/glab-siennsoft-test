using System;
using System.Collections.Generic;
using System.Text;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Glabsiennsoft.DataRepository.Exceptions;

namespace Glabsiennsoft.DataRepository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ICommonDb _commonDb;

        public CategoryRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public Guid Create(string description)
        {
            try
            {
                var productUnit = new ProductUnit { Description = description };
                _commonDb.ExecuteNonQuery("insert into units(code, description) values(@code, @description)",
                    productUnit);

                return productUnit.Code;
            }
            catch (Exception e)
            {
                throw new CategoryOperationException("Unit create error!", e);
            }
        }

        public ProductCategory Get(Guid code)
        {
            try
            {
                return _commonDb.ExecuteScalar<ProductCategory>("select * from categories where code = @code", new { code });
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Category with code {code} get error!", e);
            }
        }

        public IEnumerable<ProductCategory> Get()
        {
            try
            {
                return _commonDb.Query<ProductCategory>("select * from categories");
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Categories get error!", e);
            }
        }

        public CategoryCollectionInfo Get(int pageNumber, int pageSize)
        {
            try
            {
                var collectionInfo = new CategoryCollectionInfo();
                var query = $"select * from categories order by code offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only";
                collectionInfo.Entities = _commonDb.Query<ProductCategory>(query);
                _commonDb.GetPageCount(pageSize, $"select count(1) from categories", collectionInfo);

                return collectionInfo;
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Categories get error!", e);
            }
        }

        public int GetPageCount(int pageSize)
        {
            try
            {
                var count = _commonDb.ExecuteScalar<int>($"select count(1) from categories");
                return count / pageSize + count % pageSize;
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Categories get page size error!", e);
            }
        }

        public void Update(ProductCategory productEntity)
        {
            try
            {
                _commonDb.ExecuteNonQuery("update categories set description = @description where code = @code", productEntity);
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Category {productEntity} update error!", e);
            }
        }

        public void Remove(Guid code)
        {
            try
            {
                _commonDb.ExecuteNonQuery("delete categories where code = @code", new { code });
            }
            catch (Exception e)
            {
                throw new CategoryOperationException($"Category with {code} delete error!", e);
            }
        }
    }
}
