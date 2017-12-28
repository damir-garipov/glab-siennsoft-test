using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glabsiennsoft.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return _categoryRepository.Get();
        }

        // GET: api/Category/5
        [HttpGet("{code}")]
        public ProductCategory Get(Guid code)
        {
            return _categoryRepository.Get(code);
        }

        [Route("page")]
        [HttpGet]
        public CategoryCollectionInfo Get(int pageNumber, int pageSize)
        {
            return _categoryRepository.Get(pageNumber, pageSize);
        }
        
        // POST: api/Category
        [HttpPost]
        public bool Post([FromBody]string value)
        {
            _categoryRepository.Create(value);
            return true;
        }
        
        // PUT: api/Category/5
        [HttpPut("{code}")]
        public bool Put(Guid code, [FromBody]ProductCategory value)
        {
            _categoryRepository.Update(value);
            return true;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public bool Delete(Guid code)
        {
            _categoryRepository.Remove(code);
            return true;
        }
    }
}
