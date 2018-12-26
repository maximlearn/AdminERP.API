using AutoMapper;
using DataEntities.AdminERPContext.Models;
using System.Linq;
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
            var context = new AdminERPContext(connectionString);
            var assetItems = context
   .Asset.Include(x => x.AssetCategory)
   .Include(x => x.AssetDetail)
   .ThenInclude(y => y.Vendor);
   //.SingleOrDefault(x => x.BookId == "some example id")
  
          //  var assetItems = context.Asset.Include(x => x.AssetCategory).Include(y => y.AssetDetail.Select(i=>i.Vendor));

            //var assetItems = context.Asset.Select(x => new
            //{
            //    AssetCategory = x.AssetCategory,
            //    AssetDetail = x.AssetDetail,
            //    Vendor = x.AssetDetail.Select(y=>y.Vendor)
            //}).ToList();
            return modelMapper.Map<List<AssetModel>>(assetItems);
        }

    }
}
