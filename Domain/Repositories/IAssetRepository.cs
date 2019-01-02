using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        IEnumerable<AssetModel> GetAllAsset();
        ResponseMessage SaveAsset(AssetModel assetModel);
        AssetModel GetAssetById(int assetId);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
        ResponseMessage IsAssetExist(string AssetTagId);
    }
}
