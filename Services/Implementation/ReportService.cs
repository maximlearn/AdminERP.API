using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;
        public ReportService(IReportRepository _reportRepository)
        {
            reportRepository = _reportRepository;
        }

        public IEnumerable<StatusModel> GetAllGatePassStatus()
        {
            return this.reportRepository.GetAllGatePassStatus();
        }

        public IEnumerable<ReportModel> GetGatePassReportWithItems()
        {
            return this.reportRepository.GetGatePassReportWithItems();
        }

        public IEnumerable<AssetGatePassModel> GetGatePassSummaryReport()
        {
            return this.reportRepository.GetGatePassSummaryReport();
        }
    }
}
