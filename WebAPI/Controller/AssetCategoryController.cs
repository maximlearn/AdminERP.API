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
    [Route("api/assetCategory")]
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
        public ActionResult GetAllAssetCategory()
        {
            var result = this.assetCategoryService.GetAllAssetCategory();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddAssetCategory")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            ResponseModel oResponse = null;
            try
            {
               // DepartmentModel oData = JsonConvert.DeserializeObject<DepartmentModel>(departmentData);
                oResponse = this.assetCategoryService.IsExist(assetCategoryModel);
                if (!oResponse.IsExist)
                {
                    oResponse = this.assetCategoryService.SaveAssetCategory(assetCategoryModel);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = "There is problem with the service. We are notified. Please try again later...";
                return BadRequest(oResponse);

                // throw; log the error;
            }
            return Ok(oResponse);
        }

        //[HttpPost]
        //[Route("UpdateAssetCategory")]
        //[Produces(typeof(ResponseModel))]
        //public ActionResult UpdateAssetCategory(DepartmentModel departmentModel)
        //{
        //    ResponseModel oResponse = null;
        //    try
        //    {
        //      //  DepartmentModel oData = JsonConvert.DeserializeObject<DepartmentModel>(departmentData);
        //        oResponse = this.departmentService.IsExist(departmentModel);
        //        if (!oResponse.IsExist)
        //        {
        //           oResponse = this.departmentService.SaveDepartment(departmentModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oResponse.Message = "There is problem with the service. We are notified. Please try again later...";
        //        return BadRequest(oResponse);

        //        // throw; log the error;
        //    }

        //    return Ok(oResponse);
        //}

        [HttpGet]
        [Route("GetAssetCategory")]
        [Produces(typeof(DepartmentModel))]
        public ActionResult GetAssetCategoryById(int assetCategoryId)
        {
            var result = this.assetCategoryService.GetAssetCategoryById(assetCategoryId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteAssetCategory")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteAssetCategory(int assetCategoryId)
        {
            var result = this.assetCategoryService.DeleteAssetCategory(assetCategoryId);

            return Ok(result);
        }

    }
}