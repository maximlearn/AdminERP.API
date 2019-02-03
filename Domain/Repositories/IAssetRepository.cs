using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        IEnumerable<AssetModel> GetAllAsset();
        ResponseModel SaveAsset(AssetModel assetModel);
        ResponseModel DeleteAsset(int assetId);
        AssetModel GetAssetById(int assetId);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
        ResponseModel IsAssetExist(AssetModel asset);
        IEnumerable<AssetModel> GetAllAssetTag();

    }
}
