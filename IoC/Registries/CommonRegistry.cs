using DataEntities.DbContexts;
using Domain.Interface;
using Domain.Provider;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repository;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Registries
{
  public static class CommonRegistry
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<ITargetDbContext, ITargetDbContext>();
            services.AddTransient<IConnectionString, ConnectionString>();
        }

        public static void AddAppService(this IServiceCollection services)
        {
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IAssetService, AssetService>();          

        }
    }
}
