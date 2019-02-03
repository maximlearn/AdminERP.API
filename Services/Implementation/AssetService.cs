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

        public ResponseModel IsAssetExist(AssetModel asset)
        {
            return this.assetRepository.IsAssetExist(asset);
        }

        public ResponseModel SaveAsset(AssetModel assetModel)
        {
            return this.assetRepository.SaveAsset(assetModel);
        }

        public IEnumerable<AssetModel> GetAllAssetTag()
        {
            return this.assetRepository.GetAllAssetTag();
        }

        public ResponseModel DeleteAsset(int assetId)
        {
            return this.assetRepository.DeleteAsset(assetId);
        }
    }
}
