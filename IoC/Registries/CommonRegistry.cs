using DataEntities.AdminERPContext.Models;
using DataEntities.DbContexts;
using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Provider;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Repositories.DocumentRepository;
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
            services.AddScoped<ITargetDbContext, AdminERPContext>();
            services.AddTransient<IConnectionString, ConnectionString>();
        }

        public static void AddAppService(this IServiceCollection services)
        {
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IAssetGatePassService, AssetGatePassService>();
            services.AddTransient<IAssetGatePassRepository, AssetGatePassRepository>();


        }
    }
}
