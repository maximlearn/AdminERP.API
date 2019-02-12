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
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            this.departmentService = _departmentService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(IEnumerable<DepartmentModel>))]
        public ActionResult GetAllDepartments()
        {
            var result = this.departmentService.GetAllDepartments();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddDepartment")]
        [Produces(typeof(ResponseModel))]
        public ActionResult SaveDepartment(DepartmentModel departmentModel)
        {
            ResponseModel oResponse = null;
            try
            {
               // DepartmentModel oData = JsonConvert.DeserializeObject<DepartmentModel>(departmentData);
                oResponse = this.departmentService.IsExist(departmentModel);
                if (!oResponse.IsExist)
                {
                    oResponse = this.departmentService.SaveDepartment(departmentModel);
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
        //[Route("UpdateDepartment")]
        //[Produces(typeof(ResponseModel))]
        //public ActionResult UpdateDepartment(DepartmentModel departmentModel)
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
        [Route("GetDepartment")]
        [Produces(typeof(DepartmentModel))]
        public ActionResult GetDepartmentById(int departmentId)
        {
            var result = this.departmentService.GetDepartmentById(departmentId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteDepartment")]
        [Produces(typeof(ResponseModel))]
        public ActionResult DeleteDepartment(int departmentId)
        {
            var result = this.departmentService.DeleteDepartment(departmentId);

            return Ok(result);
        }

    }
}