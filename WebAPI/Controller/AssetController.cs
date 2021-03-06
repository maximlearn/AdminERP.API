﻿using System;
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
    [Authorize]
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
        [Produces(typeof(IEnumerable<AssetModel>))]
        public ActionResult GetAllAsset()
        {
            var result = this.assetService.GetAllAsset();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllAssetTag")]
        [Produces(typeof(IEnumerable<AssetModel>))]
        public ActionResult GetAllAssetTag()
        {
            var result = this.assetService.GetAllAssetTag();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllAssetCategory")]
        [Produces(typeof(IEnumerable<AssetCategoryModel>))]
        public ActionResult GetAllAssetCategory()
        {
            var result = this.assetService.GetAllAssetCategory();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllVendor")]
        [Produces(typeof(IEnumerable<VendorModel>))]
        public ActionResult GetAllVendor()
        {
            var result = this.assetService.GetAllVendor();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddAsset")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveAsset([FromQuery]string assetData)
        {
            ResponseModel objResponse = null;
            try
            {
                AssetModel ObjAssetData = JsonConvert.DeserializeObject<AssetModel>(assetData);
                objResponse = this.assetService.IsAssetExist(ObjAssetData);
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
                        ObjAssetData.AssetDetail.FirstOrDefault().WarrantyDocumentId = 
                            (documents.FirstOrDefault(x => x.FileLabel == "WarrantyDocument")) == null ? null : 
                            documents.FirstOrDefault(x => x.FileLabel == "WarrantyDocument").DocumentId;
                        ObjAssetData.AssetDetail.FirstOrDefault().AssetImageId = 
                            (documents.FirstOrDefault(x => x.FileLabel == "AssetImage")==null) ? null 
                            : documents.FirstOrDefault(x => x.FileLabel == "AssetImage").DocumentId;
                    }
                    objResponse = this.assetService.SaveAsset(ObjAssetData);
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

        [HttpPost]
        [Route("UpdateAsset")]
        [Produces(typeof(ResponseModel))]
        public ActionResult UpdateAsset([FromQuery]string assetData)
        {
            ResponseModel objResponse = null;
            try
            {
                AssetModel ObjAssetData = JsonConvert.DeserializeObject<AssetModel>(assetData);
                objResponse = this.assetService.IsAssetExist(ObjAssetData);
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
                        ObjAssetData.AssetDetail.FirstOrDefault().WarrantyDocumentId =
                            (documents.FirstOrDefault(x => x.FileLabel == "WarrantyDocument")) == null ? ObjAssetData.AssetDetail.FirstOrDefault().WarrantyDocumentId :
                            documents.FirstOrDefault(x => x.FileLabel == "WarrantyDocument").DocumentId;
                        ObjAssetData.AssetDetail.FirstOrDefault().AssetImageId =
                            (documents.FirstOrDefault(x => x.FileLabel == "AssetImage") == null) ? ObjAssetData.AssetDetail.FirstOrDefault().AssetImageId
                            : documents.FirstOrDefault(x => x.FileLabel == "AssetImage").DocumentId;
                    }
                    objResponse = this.assetService.SaveAsset(ObjAssetData);
                }
            }
            catch
            {
                objResponse.Message = "There is problem with the service.We are notified. Please try again later...";
                return BadRequest(objResponse);

                // throw; log the error;
            }

            return Ok(objResponse);
        }

        [HttpPost]
        [Route("DeleteAsset")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteAsset(int assetId)
        {
            var result = this.assetService.DeleteAsset(assetId);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAsset")]
        [Produces(typeof(AssetModel))]
        public ActionResult GetAssetById(int assetId)
        {
            var result = this.assetService.GetAssetById(assetId);            
            var assetImageId = result.AssetDetail.FirstOrDefault().AssetImageId;
            var warrantyDocumentId = result.AssetDetail.FirstOrDefault().WarrantyDocumentId;
            List<string> listDocumentId = new List<string>();         
            if (!string.IsNullOrWhiteSpace(assetImageId)) {
                result.DocumentList = new List<DocumentModel>();
                result.DocumentList.Add(this.documentService.GetDocumentById(assetImageId));
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("DownloadDocument")]
        [Produces(typeof(DocumentModel))]
        public ActionResult DownloadDocument(string documentId)
        {
           
            var result = this.documentService.GetDocumentById(documentId);
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
                    document.FileLabel = httpPostedFile.Name;
                    document.FileImage = ConvertStreamToByteArray(httpPostedFile);
                    document.DocumentCategory = string.Empty;
                    document.DocumentNo = string.Empty;
                    document.Description = httpPostedFile.Name;
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