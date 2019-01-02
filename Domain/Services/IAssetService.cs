using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAssetService
    {
        IEnumerable<AssetModel> GetAllAsset();
        ResponseMessage SaveAsset(AssetModel assetModel);
        IEnumerable<AssetCategoryModel> GetAllAssetCategory();
        IEnumerable<VendorModel> GetAllVendor();
        ResponseMessage IsAssetExist(string AssetTagId);
    }
}
