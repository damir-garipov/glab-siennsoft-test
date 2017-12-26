using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.Common;
using Microsoft.Extensions.Configuration;

namespace Glabsiennsoft.WebApi.Infrastructure
{
    public class GlobalSettings: IGlobalSettings
    {
        public IConfigurationRoot Configuration { get; set; }

        public string MigrationAssemblyName => Configuration.GetValue<string>("MigrationAssemblyName");
        public string DefaultConnectionString => Configuration.GetConnectionString("DefaultConnection");
    }
}
