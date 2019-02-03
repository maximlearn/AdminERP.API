using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controller
{

    [Authorize]
    [Route("api/GatePass")]
    [ApiController]
    public class AssetGatePassController : ControllerBase
    {
        public readonly IAssetGatePassService assetGatePassService;
        public AssetGatePassController(IAssetGatePassService _assetGatePassService)
        {
            assetGatePassService = _assetGatePassService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<AssetGatePassModel>))]
        public ActionResult GetAllAssetGatePassList()
        {
            var result = this.assetGatePassService.GetAllAssetGatePassList();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllGatePassType")]
        [Produces(typeof(IEnumerable<GatePassTypeModel>))]
        public ActionResult GetAllGatePassType()
        {
            var result = this.assetGatePassService.GetAllGatePassType();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUnit")]
        [Produces(typeof(IEnumerable<QuantityUnitModel>))]
        public ActionResult GetAllUnit()
        {
            var result = this.assetGatePassService.GetAllUnit();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetBlankGatePassDetail")]
        [Produces(typeof(AssetGatePassDetailModel))]
        public ActionResult GetBlankGatePassDetail()
        {
            var gatePassDetail = new AssetGatePassDetailModel() {
                AssetTypeId = -101,
                SendQtyUnitId = -101,
                Asset = new AssetModel() {
                    AssetDetail = new List<AssetDetailModel>() { new AssetDetailModel() } 
            } 
            };
            return Ok(gatePassDetail);
        }

        [HttpGet]
        [Route("GetGatePassById")]
        [Produces(typeof(AssetGatePassModel))]
        public ActionResult GetGatePassDetailById(int gatePassId)
        {
            var result = this.assetGatePassService.GetGatePassDetailById(gatePassId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveAssetGatePass")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveAssetGatePass(AssetGatePassModel assetGatePassModel)
        {
          //  AssetGatePassModel ObjAssetData = JsonConvert.DeserializeObject<AssetGatePassModel>(assetGatePassModel);
            var result = this.assetGatePassService.SaveAssetGatePass(assetGatePassModel);
            return Ok(result);
        }

       

        [HttpPost]
        [Route("DeleteAssetGatePass")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteAssetGatePass(int gatePassId)
        {
            //  AssetGatePassModel ObjAssetData = JsonConvert.DeserializeObject<AssetGatePassModel>(assetGatePassModel);
            var result = this.assetGatePassService.DeleteAssetGatePass(gatePassId);
            return Ok(result);
        }






    }
}