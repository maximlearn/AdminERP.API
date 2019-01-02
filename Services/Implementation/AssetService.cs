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

        public AssetModel GetAssetById(int assetId)
        {
            return this.assetRepository.GetAssetById(assetId);
        }

        public IEnumerable<AssetCategoryModel> GetAllAssetCategory()
        {
            return this.assetRepository.GetAllAssetCategory();
        }

        public IEnumerable<VendorModel> GetAllVendor()
        {
            return this.assetRepository.GetAllVendor();
        }

        public ResponseMessage IsAssetExist(string AssetTagId)
        {
            return this.assetRepository.IsAssetExist(AssetTagId);
        }

        public ResponseMessage SaveAsset(AssetModel assetModel)
        {
            return this.assetRepository.SaveAsset(assetModel);
        }
    }
}
