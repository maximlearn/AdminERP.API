using Domain.Model;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class AssetService : IAssetService
    {
        public readonly IAssetRepository assetRepository;
        public AssetService(IAssetRepository _assetRepository)
        {
            this.assetRepository = _assetRepository;
        }

        public IEnumerable<AssetModel> GetAllAsset()
        {
            return this.assetRepository.GetAllAsset();
        }
    }
}
