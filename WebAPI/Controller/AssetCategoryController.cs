using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controller
{
    [Route("api/assetcategory")]
    [ApiController]
    public class AssetCategoryController : ControllerBase
    {
        public readonly IAssetCategoryService assetCategoryService;

        public AssetCategoryController(IAssetCategoryService _assetCategoryService)
        {
            this.assetCategoryService = _assetCategoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<AssetCategoryModel>))]
        public ActionResult GetAllCategories()
        {
            var result = this.assetCategoryService.GetAllCategories();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddCategory")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveDepartment(AssetCategoryModel assetCategoryData)
        {
            var result = this.assetCategoryService.SaveCategory(assetCategoryData);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("GetCategory")]
        [Produces(typeof(AssetCategoryModel))]
        public ActionResult GetCategoryById(int categoryId)
        {
            var result = this.assetCategoryService.GetCategoryById(categoryId);

            return Ok(result);
        }

    }
}