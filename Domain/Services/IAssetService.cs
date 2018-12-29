using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAssetService
    {
        IEnumerable<AssetModel> GetAllAsset();
        AssetModel SaveAsset(AssetModel assetModel);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
    }
}
