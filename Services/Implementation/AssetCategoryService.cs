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
        private readonly IAssetCategoryRepository categoryRepository;

        public AssetCategoryService(IAssetCategoryRepository _categoryRepository)
        {
            this.categoryRepository = _categoryRepository;
        }

        public IEnumerable<AssetCategoryModel> GetAllCategories()
        {
            return this.categoryRepository.GetAllCategories();
        }

        public AssetCategoryModel GetCategoryById(int categoryId)
        {
            return this.categoryRepository.GetAssetCategoryById(categoryId);
        }

        public ResponseModel IsExist(int categoryId)
        {
            return this.categoryRepository.IsExist(categoryId);
        }

        public ResponseModel SaveCategory(AssetCategoryModel assetCategoryModel)
        {
            return this.categoryRepository.SaveAssetCategory(assetCategoryModel);
        }
    }
}
