using System;
using System.Collections.Generic;
using Glabsiennsoft.Contracts.CollectionInfos;
using Glabsiennsoft.Contracts.DataModel;
using Glabsiennsoft.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Glabsiennsoft.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private readonly IUnitRepository _unitRepository;

        public UnitController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        // GET: api/Unit
        [HttpGet]
        public IEnumerable<ProductUnit> Get()
        {
            return _unitRepository.Get();
        }

        // GET: api/Unit/5
        [HttpGet("{code}")]
        public ProductUnit Get(Guid code)
        {
            return _unitRepository.Get(code);
        }

        [Route("page")]
        [HttpGet]
        public UnitCollectionInfo Get(int pageNumber, int pageSize)
        {
            return _unitRepository.Get(pageNumber, pageSize);
        }

        // POST: api/Unit
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _unitRepository.Create(value);
        }

        // PUT: api/Unit/5
        [HttpPut("{code}")]
        public void Put(Guid code, [FromBody]ProductUnit value)
        {
            _unitRepository.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public void Delete(Guid code)
        {
            _unitRepository.Remove(code);
        }
    }
}