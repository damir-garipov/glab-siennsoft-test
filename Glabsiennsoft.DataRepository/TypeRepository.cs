using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Glabsiennsoft.DataRepository.Exceptions;

namespace Glabsiennsoft.DataRepository
{
    public class TypeRepository: ITypeRepository
    {
        private readonly ICommonDb _commonDb;

        public TypeRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public Guid Create(string description)
        {
            try
            {
                var productType = new ProductType { Description = description };
                _commonDb.ExecuteNonQuery("insert into types(code, description) values(@code, @description)",
                    productType);

                return productType.Code;
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException("Type create error!", e);
            }
        }

        public ProductType Get(Guid code)
        {
            try
            {
                return _commonDb.Query<ProductType>("select * from types where code = @code", new { code }).First();
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Type with code {code} get error!", e);
            }
        }

        public IEnumerable<ProductType> Get()
        {
            try
            {
                return _commonDb.Query<ProductType>("select * from types");
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Types get error!", e);
            }
        }

        public TypeCollectionInfo Get(int pageNumber, int pageSize)
        {
            try
            {
                var collectionInfo = new TypeCollectionInfo();
                var query = $"select * from types order by code offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only";
                collectionInfo.Entities = _commonDb.Query<ProductType>(query);

                _commonDb.GetPageCount(pageSize, "select count(1) from types", collectionInfo);
                return collectionInfo;
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Types get error!", e);
            }
        }

        public int GetPageCount(int pageSize)
        {
            try
            {
                var count = _commonDb.ExecuteScalar<int>($"select count(1) from types");
                return count / pageSize + count % pageSize;
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Types get page size error!", e);
            }
        }

        public void Update(ProductType productType)
        {
            try
            {
                _commonDb.ExecuteNonQuery("update types set description = @description where code = @code", productType);
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Unit {productType} update error!", e);
            }
        }

        public void Remove(Guid code)
        {
            try
            {
                _commonDb.ExecuteNonQuery("delete types where code = @code", new { code });
            }
            catch (Exception e)
            {
                throw new ProductTypeOperationException($"Type with {code} delete error!", e);
            }
        }
    }
}
