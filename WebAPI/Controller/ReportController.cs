using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public readonly IReportService reportService;
        public readonly IDocumentService documentService;

        public ReportController(IReportService _reportService, IDocumentService _documentService)
        {
            this.reportService = _reportService;
            this.documentService = _documentService;
        }

        [HttpGet]
        [Route("GetAllGatePassStatus")]
        [Produces(typeof(IEnumerable<StatusModel>))]
        public ActionResult GetAllGatePassStatus()
        {
            var result = this.reportService.GetAllGatePassStatus();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGatePassSummaryReport")]
        [Produces(typeof(IEnumerable<AssetGatePassModel>))]
        public ActionResult GetGatePassSummaryReport()
        {
            var result = this.reportService.GetGatePassSummaryReport();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGatePassReportWithItems")]
        [Produces(typeof(IEnumerable<ReportModel>))]
        public ActionResult GetGatePassReportWithItems()
        {
            var result = this.reportService.GetGatePassReportWithItems();
            return Ok(result);
        }

    }
}