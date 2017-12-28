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
    public class ProductRepository: IProductRepository
    {
        private readonly ICommonDb _commonDb;
        private readonly ITypeRepository _typeRepository;
        private readonly IUnitRepository _unitRepository;
        private const string SubQuery = "select *, (select description from types where code = codeType) as typeDescription, (select description from units where code = codeUnit) as unitDescription from products";

        public ProductRepository(ICommonDb commonDb, ITypeRepository typeRepository, IUnitRepository unitRepository)
        {
            _commonDb = commonDb;
            _typeRepository = typeRepository;
            _unitRepository = unitRepository;
        }

        public Guid Create(Product product)
        {
            try
            {
                _commonDb.ExecuteNonQuery("insert into products(code, description, price, isAvailable, deliveryDate, codeType, codeUnit) " +
                                          "values(@code, @description, @price, @isAvailable, @deliveryDate, @codeType, @codeUnit)",
                    product);

                return product.Code;
            }
            catch (Exception e)
            {
                throw new ProductOperationException("Product create error!", e);
            }
        }

        public Product Get(Guid code)
        {
            try
            {
                return _commonDb.Query<Product>("select * from products where code = @code", new { code }).First();
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Product with code {code} get error!", e);
            }
        }

        public IEnumerable<Product> Get()
        {
            try
            {
                return _commonDb.Query<Product>("select * from products");
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Products get error!", e);
            }
        }

        public ProductCollectionInfo Get(int pageNumber, int pageSize)
        {
            try
            {
                var products = _commonDb.Query<ProductWithDescription>($"select * from ({SubQuery}) subQuery order by code offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only");
                var collectionInfo = new ProductCollectionInfo();
                _commonDb.GetPageCount(pageSize, "select count(1) from products", collectionInfo);
                collectionInfo.Entities = products;

                return collectionInfo;
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Products get error!", e);
            }
        }

        public ProductCollectionInfo GetAvailableProducts(int pageNumber, int pageSize)
        {
            try
            {
                var products = _commonDb.Query<ProductWithDescription>($"select * from ({SubQuery}) subQuery where isAvailable = 1 order by code offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only");

                var collectionInfo = new ProductCollectionInfo();
                _commonDb.GetPageCount(pageSize, "select count(1) from products where isAvailable = 1", collectionInfo);
                collectionInfo.Entities = products;

                return collectionInfo;
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Products get error!", e);
            }
        }

        public ProductCollectionInfo GetByFilterProducts(int pageNumber, int pageSize, Guid? type, Guid? unit, IEnumerable<Guid> categories)
        {
            var queryBuilder = new StringBuilder($"select p.* from ({SubQuery}) p").AppendLine();
            var codes = categories as Guid[] ?? categories?.ToArray();
            if (codes != null && codes.Any())
            {
                var joinCodes = codes.Aggregate("", (c,n) => c + $"'{n}',");
                var categoryFilterString = $"inner join (select * from productcategories where codeCategory in ({joinCodes.Remove(joinCodes.Length - 1)})) c on p.code = c.codeProduct";
                queryBuilder.AppendLine(categoryFilterString);
            }

            var isWhere = false;
            if (type.HasValue)
            {
                isWhere = true;
                queryBuilder.AppendLine("where");
                queryBuilder.AppendLine($"codeType = '{type.Value}'");
            }

            if (unit.HasValue)
            {
                queryBuilder.AppendLine($"{(isWhere ? "and" : "where")} codeUnit = '{unit.Value}'");
            }

            queryBuilder.AppendLine("group by p.code, p.description, p.price, p.isAvailable, p.deliveryDate, p.codeType, p.codeUnit");
            queryBuilder.AppendLine($"order by code offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only");

            try
            {
                var query = queryBuilder.ToString();
                var products = _commonDb.Query<ProductWithDescription>(query);

                var collectionInfo = new ProductCollectionInfo();
                _commonDb.GetPageCount(pageSize, $"select count(1) from ({query}) countSet", collectionInfo);
                collectionInfo.Entities = products;

                return collectionInfo;
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Products get error!", e);
            }

        }

        public ProductInfo GetProductInfo(Guid code)
        {
            const string query = "select p.description productDescription, p.price, p.code, p.isAvailable, p.deliveryDate, p.codeType, p.codeUnit, isnull(count(pc.codeCategory), 0) categoryCount from products p left join productcategories pc on p.code = pc.codeProduct where p.code = @code group by p.code, p.description, p.price, p.isAvailable, p.deliveryDate, p.codeType, p.codeUnit";
            try
            {
                var raw = _commonDb.Query<ProductInfoRaw>(query, new { code }).First();
                return new ProductInfo(raw, _typeRepository, _unitRepository);
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Get ProductInfo by code {code} error!", e);
            }
        }

        public void Update(Product product)
        {
            try
            {
                _commonDb.ExecuteNonQuery("update products set description = @description, price = @price, isAvailable = @isAvailable, deliveryDate = @deliveryDate, codeType = @codeType, codeUnit = @codeUnit where code = @code", product);
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Product {product} update error!", e);
            }
        }

        public void Remove(Guid code)
        {
            try
            {
                _commonDb.ExecuteNonQuery("delete products where code = @code", new { code });
            }
            catch (Exception e)
            {
                throw new ProductOperationException($"Product with {code} delete error!", e);
            }
        }
    }
}
