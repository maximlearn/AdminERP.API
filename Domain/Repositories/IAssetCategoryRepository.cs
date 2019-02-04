using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAssetCategoryRepository
    {
        IEnumerable<AssetCategoryModel> GetAllCategories();
        ResponseModel SaveAssetCategory(AssetCategoryModel categoryModel);
        AssetCategoryModel GetAssetCategoryById(int categoryId);
        ResponseModel IsExist(int Id);
    }
}
