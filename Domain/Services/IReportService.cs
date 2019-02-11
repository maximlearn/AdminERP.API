using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
   public interface IReportService
    {
        IEnumerable<AssetGatePassModel> GetGatePassSummaryReport();
        IEnumerable<ReportModel> GetGatePassReportWithItems();
        IEnumerable<StatusModel> GetAllGatePassStatus();
    }
}
