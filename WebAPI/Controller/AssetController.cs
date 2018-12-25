using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        public readonly IAssetService assetService;

        public AssetController(IAssetService _assetService)
        {
            this.assetService = _assetService;
        }

        public ActionResult GetAllAsset()
        {
            var result = this.assetService.GetAllAsset();

            return Ok(result);
        }
    }
}