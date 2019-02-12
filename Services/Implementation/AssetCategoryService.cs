using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly IAssetCategoryRepository assetCategoryRepository;

        public AssetCategoryService(IAssetCategoryRepository _assetCategoryRepository)
        {
            this.assetCategoryRepository = _assetCategoryRepository;
        }

        public AssetCategoryModel GetAssetCategoryById(int assetCategoryId)
        {
            return this.assetCategoryRepository.GetAssetCategoryById(assetCategoryId);
        }

        public ResponseModel SaveAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            return this.assetCategoryRepository.SaveAssetCategory(assetCategoryModel);
        }

        public ResponseModel DeleteAssetCategory(int assetCategoryId)
        {
            return this.assetCategoryRepository.DeleteAssetCategory(assetCategoryId);
        }

        public ResponseModel IsExist(AssetCategoryModel assetCategoryModel)
        {
            return this.assetCategoryRepository.IsExist(assetCategoryModel);
        }

        public IEnumerable<AssetCategoryModel> GetAllAssetCategory()
        {
            return this.assetCategoryRepository.GetAllAssetCategory();
        }
    }
}
