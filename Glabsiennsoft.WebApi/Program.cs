using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Glabsiennsoft.WebApi
{
    public class Program
    {
        private static readonly string EnvironmentName
#if DEBUG
        = string.Empty;
#elif DEV
         = "Development";
#elif RELEASE
         = "Production";
#endif
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseEnvironment(EnvironmentName)
                .Build();
    }
}
