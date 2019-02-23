using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class AssetGatePassService : IAssetGatePassService
    {
        private readonly IAssetGatePassRepository assetGatePassRepository;
        public AssetGatePassService(IAssetGatePassRepository _assetGatePassRepository)
        {
            assetGatePassRepository = _assetGatePassRepository;
        }

        public ResponseModel DeleteAssetGatePass(int gatePassId)
        {
            return this.assetGatePassRepository.DeleteAssetGatePass(gatePassId);
        }

        public IEnumerable<AssetGatePassModel> GetAllAssetGatePassList()
        {
            return this.assetGatePassRepository.GetAllAssetGatePassList();
        }

        public IEnumerable<GatePassTypeModel> GetAllGatePassType()
        {
            return this.assetGatePassRepository.GetAllGatePassType();
        }

        public IEnumerable<QuantityUnitModel> GetAllUnit()
        {
            return this.assetGatePassRepository.GetAllUnit();
        }

        public AssetGatePassModel GetGatePassDetailById(int gatePassId)
        {
            return this.assetGatePassRepository.GetGatePassDetailById(gatePassId);
        }

        public ResponseModel SaveAssetGatePass(AssetGatePassModel assetGatePassModel)
        {
            return this.assetGatePassRepository.SaveAssetGatePass(assetGatePassModel);
        }

        public ResponseModel UpdateGatePassStatus(AssetGatePassModel assetGatePass)
        {
            return this.assetGatePassRepository.UpdateGatePassStatus(assetGatePass);
        }
    }
}
