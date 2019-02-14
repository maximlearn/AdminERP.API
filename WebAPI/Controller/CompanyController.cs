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
    [Authorize]
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly ICompanyService companyService;
        public readonly IDocumentService documentService;

        public CompanyController(ICompanyService _companyService, IDocumentService _documentService)
        {
            this.companyService = _companyService;
            this.documentService = _documentService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<CompanyModel>))]
        public ActionResult GetAllCompany()
        {
            var result = this.companyService.GetAllCompany();
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

        [HttpPost]
        [Route("SaveCompany")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveCompany([FromQuery]string companyData)
        {
            ResponseModel oResponse = null;
            try
            {
                CompanyModel companyModel = JsonConvert.DeserializeObject<CompanyModel>(companyData);
                oResponse = this.companyService.IsExist(companyModel);
                if (!oResponse.IsExist)
                {

                    List<DocumentModel> documents = null;
                    if (Request.ContentLength > 0)
                    {
                        var files = Request.Form.Files;
                        documents = UploadFiles(files);
                    }

                    if (documents != null)
                    {
                        companyModel.CompanyLogoId= (documents.FirstOrDefault(x => x.FileLabel == "CompanyLogo")) == null ? null :
                           documents.FirstOrDefault(x => x.FileLabel == "CompanyLogo").DocumentId;                       
                    }
                  
                    oResponse = this.companyService.SaveCompany(companyModel);
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = "There is problem with the service.We are notified. Please try again later...";
                return BadRequest(oResponse);

                // throw; log the error;
            }
            return Ok(oResponse);
        }

        [HttpPost]
        [Route("UpdateCompany")]
        [Produces(typeof(ResponseModel))]
        public ActionResult UpdateCompany([FromQuery]string companyData)
        {
            ResponseModel oResponse = null;
            try
            {
                CompanyModel companyModel = JsonConvert.DeserializeObject<CompanyModel>(companyData);
                oResponse = this.companyService.IsExist(companyModel);
                if (!oResponse.IsExist)
                {
                    List<DocumentModel> documents = null;
                    if (Request.ContentLength > 0)
                    {
                        var files = Request.Form.Files;
                        documents = UploadFiles(files);
                    }

                    if (documents != null)
                    {
                        companyModel.CompanyLogoId = (documents.FirstOrDefault(x => x.FileLabel == "CompanyLogo")) == null ? null :
                           documents.FirstOrDefault(x => x.FileLabel == "CompanyLogo").DocumentId;
                    }

                    oResponse = this.companyService.SaveCompany(companyModel);

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

        [HttpGet]
        [Route("GetCompany")]
        [Produces(typeof(CompanyModel))]
        public ActionResult GetCompanyById(int companyId)
        {
            var result = this.companyService.GetCompanyById(companyId);
            List<string> listDocumentId = new List<string>();
            if (!string.IsNullOrWhiteSpace(result.CompanyLogoId))
            {
                result.companyLogo =  this.documentService.GetDocumentById(result.CompanyLogoId);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteCompany")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteCompany(int companyId)
        {
            var result = this.companyService.DeleteCompany(companyId);

            return Ok(result);
        }

    }
}