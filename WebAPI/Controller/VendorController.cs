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
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        public readonly IVendorService vendorService;

        public VendorController(IVendorService _vendorService)
        {
            this.vendorService = _vendorService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<VendorModel>))]
        public ActionResult GetAllVendor()
        {
            var result = this.vendorService.GetAllVendor();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddVendor")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveVendor(VendorModel vendorModel)
        {
            ResponseModel oResponse = null;
            try
            {
               // VendorModel oData = JsonConvert.DeserializeObject<VendorModel>(vendorData);
                oResponse = this.vendorService.IsExist(vendorModel);
                if (!oResponse.IsExist)
                {
                    oResponse = this.vendorService.SaveVendor(vendorModel);
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
        //[Route("UpdateVendor")]
        //[Produces(typeof(ResponseModel))]
        //public ActionResult UpdateVendor(VendorModel vendorModel)
        //{
        //    ResponseModel oResponse = null;
        //    try
        //    {
        //      //  VendorModel oData = JsonConvert.DeserializeObject<VendorModel>(vendorData);
        //        oResponse = this.vendorService.IsExist(vendorModel);
        //        if (!oResponse.IsExist)
        //        {
        //           oResponse = this.vendorService.SaveVendor(vendorModel);
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
        [Route("GetVendor")]
        [Produces(typeof(VendorModel))]
        public ActionResult GetVendorById(int vendorId)
        {
            var result = this.vendorService.GetVendorById(vendorId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteVendor")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteVendor(int vendorId)
        {
            var result = this.vendorService.DeleteVendor(vendorId);

            return Ok(result);
        }

    }
}