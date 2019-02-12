using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAssetCategoryRepository
    {
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        ResponseModel SaveAssetCategory(AssetCategoryModel assetCategoryModel);
        AssetCategoryModel GetAssetCategoryById(int assetCategoryId);
        ResponseModel DeleteAssetCategory(int assetCategoryId);
        ResponseModel IsExist(AssetCategoryModel assetCategoryModel);
    }
}
