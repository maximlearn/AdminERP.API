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
        [Route("GetAll")]
        public ActionResult GetAllAsset()
        {
            var result = this.assetService.GetAllAsset();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllAssetCategory")]
        public ActionResult GetAllAssetCategory()
        {
            var result = this.assetService.GetAllAssetCategory();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllVendor")]
        public ActionResult GetAllVendor()
        {
            var result = this.assetService.GetAllVendor();
            return Ok(result);
        }


        [HttpPost]
        [Route("AddAsset")]
        public ActionResult SaveAsset(AssetModel assetModel)
        {
            var result = this.assetService.SaveAsset(assetModel);           
            return Ok(result);
        }

        [HttpPost]
        [Route("UploadAssetDocument")]
        public ActionResult UploadAssetDocument()
        {
            var files = Request.Form.Files;
            UploadFiles(files);
            return Ok();
        }



        private void UploadFiles(IFormFileCollection files)
        {           
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var postedFile = file;
                    string fullPath = Path.Combine("/UploadFiles/", postedFile.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        try
                        {
                            file.CopyTo(stream);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    // var filePath = HttpContext.Server.MapPath("~/UploadedFiles/" + postedFile.FileName);


                }
            }
        }
    }
}