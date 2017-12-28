using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Glabsiennsoft.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glabsiennsoft.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }

        // GET: api/Product/5
        [HttpGet("{code}")]
        public Product Get(Guid code)
        {
            return _productRepository.Get(code);
        }


        [Route("{code}/info")]
        [HttpGet]
        public ProductInfo GetProductInfo(Guid code)
        {
            return _productRepository.GetProductInfo(code);
        }

        [Route("available")]
        [HttpGet]
        public ProductCollectionInfo GetAvailableProducts(int pageNumber, int pageSize)
        {
            return _productRepository.GetAvailableProducts(pageNumber, pageSize);
        }

        [Route("filter")]
        [HttpPost]
        public ProductCollectionInfo GetFiltrationProducts([FromBody] ProductFilter filter)
        {
            return _productRepository.GetByFilterProducts(filter.PageNumber, filter.PageSize, filter.Type, filter.Unit,
                filter.Categories);
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            _productRepository.Create(value);
        }
        
        // PUT: api/Product/5
        [HttpPut("{code}")]
        public void Put(Guid code, [FromBody]Product product)
        {
            _productRepository.Update(product);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public void Delete(Guid code)
        {
            _productRepository.Remove(code);
        }
    }
}
