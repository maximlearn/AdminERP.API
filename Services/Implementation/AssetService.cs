using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
   public class AssetService : IAssetService
    {
        private readonly IAssetRepository assetRepository;
        public AssetService(IAssetRepository _assetRespoitory)
        {
            this.assetRepository = _assetRespoitory;
        }

        public IEnumerable<AssetModel> GetAllAsset()
        {
            return this.assetRepository.GetAllAsset();
        }
    }
}
