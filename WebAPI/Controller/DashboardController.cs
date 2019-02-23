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
    [Route("api/department")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService _dashboardService)
        {
            dashboardService = _dashboardService;
        }

        [HttpGet]
        [Route("GetAllDashboardData")]
        [Produces(typeof(DashboardModel))]
        public ActionResult GetAllDashboardData(int userId)
        {
            var result = this.dashboardService.GetDashboardData(userId);
            return Ok(result);
        }
    }
}