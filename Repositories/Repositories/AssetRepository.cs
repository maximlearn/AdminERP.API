using Domain.Model;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
   public class AssetRepository : IAssetRepository
    {

        public AssetRepository()
        {

        }

        public IEnumerable<AssetModel> GetAllAsset()
        {
            throw new NotImplementedException();
        }
    }
}
