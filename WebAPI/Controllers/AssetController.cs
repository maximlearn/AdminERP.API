using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService assetService;
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