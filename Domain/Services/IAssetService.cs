using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
   public interface IAssetService
    {
       IEnumerable<AssetModel> GetAllAsset();
    }
}
