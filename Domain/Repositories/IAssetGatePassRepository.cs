using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAssetGatePassRepository
    {
        IEnumerable<AssetGatePassModel> GetAllAssetGatePassList();
        IEnumerable<GatePassTypeModel> GetAllGatePassType();
        ResponseModel SaveAssetGatePass(AssetGatePassModel assetGatePassModel);
        AssetGatePassModel GetGatePassDetailById(int assetGatePassId);
        IEnumerable<QuantityUnitModel> GetAllUnit();
        ResponseModel DeleteAssetGatePass(int gatePassId);
        ResponseModel UpdateGatePassStatus(AssetGatePassModel assetGatePass);

    }
}
