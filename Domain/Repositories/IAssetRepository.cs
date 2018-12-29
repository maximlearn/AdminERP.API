using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAssetRepository
    {
        IEnumerable<AssetModel> GetAllAsset();
        AssetModel GetAssetById(int assetId);
        //Task<AssetModel> GetById(int assetId);
        AssetModel SaveAsset(AssetModel assetModel);
    }
}
