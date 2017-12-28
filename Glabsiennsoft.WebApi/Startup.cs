using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.WebApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;

namespace Glabsiennsoft.WebApi
{
    public class Startup
    {
        public GlobalSettings _globalSettings { get; }

        public Startup(IHostingEnvironment env)
        {
            _globalSettings = new GlobalSettings();
            env.ConfigureNLog("nlog.config");

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _globalSettings.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGlobalSettings>(_globalSettings);
            services.AddApplicationDependency();
            services.AddMvc();
            services.AddLogging();

            services.AddCors(options => options.AddPolicy("CORS",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));

            // Register the Swagger generator, defining one or more Swagger documents
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
//            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CORS");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
//            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//            });

            app.UseMvc();
        }
    }
}
