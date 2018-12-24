using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Registries
{
    public static class CommonRegistry
    {      

        public static void AddAppService(this IServiceCollection services)       
        {
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IAssetService, AssetService>();
        }
    }
}
