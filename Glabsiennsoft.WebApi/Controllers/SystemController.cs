using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.Common.MIgrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glabsiennsoft.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/system")]
    public class SystemController : Controller
    {
        private readonly IMigrator _migrator;

        public SystemController(IMigrator migrator)
        {
            _migrator = migrator;
        }

        [Route("migration/up")]
        public IActionResult MigrateUp()
        {
            try
            {
                _migrator.Up();
                return Ok(new {result = "Ok!"});

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("migration/down/{migrationName}")]
        public IActionResult MigrateDown(string migrationName)
        {
            try
            {
                _migrator.Down(migrationName);
                return Ok(new { result = "Ok!" });

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}