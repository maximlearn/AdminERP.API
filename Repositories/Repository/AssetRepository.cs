using AutoMapper;
using DataEntities.AdminERPContext.Models;

using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public AssetRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext,  IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<AssetModel> GetAllAsset()
        {
            var context = new AdminERPContext(this.connectionString);
            var assetItems = context.Asset.Include("AssetDetail").Include("AssetCategory");
            return modelMapper.Map<List<AssetModel>>(assetItems);
        }

    }
}
