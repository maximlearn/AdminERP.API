using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
   public interface IReportRepository
    {
        IEnumerable<AssetGatePassModel> GetGatePassSummaryReport();
        IEnumerable<ReportModel> GetGatePassReportWithItems();
        IEnumerable<StatusModel> GetAllGatePassStatus();
    }
}
