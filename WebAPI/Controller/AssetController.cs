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
    [AllowAnonymous]
    [Route("api/Asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        public readonly IAssetService assetService;
        public readonly IDocumentService documentService;

        public AssetController(IAssetService _assetService, IDocumentService _documentService)
        {
            this.assetService = _assetService;
            this.documentService = _documentService;
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
        // public ActionResult SaveAsset([FromQuery]string assetData)
        public ActionResult SaveAsset([FromQuery]string assetData)
        {
            ResponseMessage objResponse = null;
            try
            {
                AssetModel ObjAssetData = JsonConvert.DeserializeObject<AssetModel>(assetData);
                objResponse = this.assetService.IsAssetExist(ObjAssetData.AssetTagId);
                if (!objResponse.IsExist)
                {
                    List<DocumentModel> documents = null;
                    if (Request.ContentLength > 0)
                    {
                        var files = Request.Form.Files;
                        documents = UploadFiles(files);
                    }

                    if (documents != null)
                    {
                        ObjAssetData.AssetDetail.FirstOrDefault().WarrantyDocumentId = documents.FirstOrDefault(x => x.FileLable == "WarrantyDocument").DocumentId;
                        ObjAssetData.AssetDetail.FirstOrDefault().AssetImageId = documents.FirstOrDefault(x => x.FileLable == "AssetImage").DocumentId;

                        objResponse = this.assetService.SaveAsset(ObjAssetData);                       
                    }
                    else
                    {
                        objResponse.Message = "There is problem with the service.We are notified. Please try again later...";
                        return BadRequest(objResponse);
                    }
                }

            }
            catch (Exception ex)
            {
                objResponse.Message = "There is problem with the service.We are notified. Please try again later...";
                return BadRequest(objResponse);

               // throw; log the error;
            }

            return Ok(objResponse);
        }

        [HttpGet]
        [Route("GetAsset")]
        public ActionResult GetAssetById(int assetId)
        {
            var result = this.assetService.GetAssetById(assetId);

            return Ok(result);
        }

        private List<DocumentModel> UploadFiles(IFormFileCollection httpPostedFiles)
        {

            // return documentService.SaveDocument(files);
            List<DocumentModel> documents = new List<DocumentModel>();
            DocumentModel document = null;
            if (httpPostedFiles.Count > 0)
            {
                foreach (var httpPostedFile in httpPostedFiles)
                {
                    document = new DocumentModel();
                    document.DocumentId = Guid.NewGuid().ToString();
                    document.FileName = httpPostedFile.FileName;
                    document.FileLable = httpPostedFile.Name;
                    document.FileImage = ConvertStreamToByteArray(httpPostedFile);
                    document.DocumentCategory = string.Empty;
                    document.DocumentNo = string.Empty;
                    document.Description = string.Empty;
                    document.Keyword = string.Empty;
                    document.DocumentType = httpPostedFile.ContentType;
                    Boolean IsDocumentSaved = this.documentService.SaveDocument(document);
                    if (IsDocumentSaved)
                    { documents.Add(document); }
                }
            }
            if (documents.Count == httpPostedFiles.Count)
                return documents;
            else
                return null;
        }


        private byte[] ConvertStreamToByteArray(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                using (memoryStream)
                {
                    return memoryStream.ToArray();
                }
            }
        }
    }
}