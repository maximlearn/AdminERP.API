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
        public ActionResult GetAllCompanies()
        {
            var result = this.companyService.GetAllCompanies();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddCompany")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveCompany([FromQuery]string companyData)
        {
            ResponseModel oResponse = null;
            try
            {
                CompanyModel oData = JsonConvert.DeserializeObject<CompanyModel>(companyData);
                oResponse = this.companyService.IsExist(oData.Id);
                if (!oResponse.IsExist)
                {
                    oResponse = this.companyService.SaveCompany(oData);
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
                CompanyModel oData = JsonConvert.DeserializeObject<CompanyModel>(companyData);
                oResponse = this.companyService.IsExist(oData.Id);
                if (!oResponse.IsExist)
                {
                   oResponse = this.companyService.SaveCompany(oData);
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

            return Ok(result);
        }

    }
}