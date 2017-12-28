using System;
using System.Collections.Generic;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Glabsiennsoft.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private readonly ITypeRepository _typeRepository;

        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        // GET: api/Type
        [HttpGet]
        public IEnumerable<ProductType> Get()
        {
            return _typeRepository.Get();
        }

        // GET: api/Type/5
        [HttpGet("{code}")]
        public ProductType Get(Guid code)
        {
            return _typeRepository.Get(code);
        }

        [Route("page")]
        [HttpGet]
        public TypeCollectionInfo Get(int pageNumber, int pageSize)
        {
            return _typeRepository.Get(pageNumber, pageSize);
        }

        // POST: api/Type
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _typeRepository.Create(value);
        }

        // PUT: api/Type/5
        [HttpPut("{code}")]
        public void Put(Guid code, [FromBody]ProductType value)
        {
            _typeRepository.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public void Delete(Guid code)
        {
            _typeRepository.Remove(code);
        }
    }
}