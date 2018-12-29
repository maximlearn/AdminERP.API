using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAssetService
    {
        IEnumerable<AssetModel> GetAllAsset();
        AssetModel GetAssetById(int assetId);
        AssetModel SaveAsset(AssetModel assetModel);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
    }
}
