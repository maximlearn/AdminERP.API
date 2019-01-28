using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAssetService
    {
        IEnumerable<AssetModel> GetAllAsset();
        ResponseModel SaveAsset(AssetModel assetModel);
        AssetModel GetAssetById(int assetId);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
        ResponseModel IsAssetExist(string AssetTagId);
        IEnumerable<AssetModel> GetAllAssetTag();
    }
}
