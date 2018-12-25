using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [AllowAnonymous]
    [Route("api/Asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        public readonly IAssetService assetService;
        
        public AssetController(IAssetService _assetService)
        {
            this.assetService = _assetService;
        }

        [HttpGet]
        public ActionResult GetAllAsset()
        {
            var result = this.assetService.GetAllAsset();

            return Ok(result);
        }
    }
}