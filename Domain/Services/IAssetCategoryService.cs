using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAssetCategoryService
    {
        IEnumerable<AssetCategoryModel> GetAllCategories();
        ResponseModel SaveCategory(AssetCategoryModel assetCategoryModel);
        AssetCategoryModel GetCategoryById(int Id);
        ResponseModel IsExist(int id);
    }
}
