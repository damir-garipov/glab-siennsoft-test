using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glabsiennsoft.Contracts.Common;
using Glabsiennsoft.Contracts.Common.MIgrations;
using Glabsiennsoft.Contracts.Repositories;
using Glabsiennsoft.DataRepository;
using Glabsiennsoft.MIgrate;
using Glabsiennsoft.Orm;
using Microsoft.Extensions.DependencyInjection;

namespace Glabsiennsoft.WebApi.Infrastructure
{
    public static class IocConfig
    {
        public static void AddApplicationDependency(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IMigrator), typeof(Migrator), ServiceLifetime.Scoped));
            services.AddScoped<ICommonDb, CommonDb>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
