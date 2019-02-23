using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class DashboardModel
    {
        public int GatPassId { get; set; }
        public int ApproveGatePass { get; set; }
        public int PendingGatePass { get; set; }
        public int RejectGatepass { get; set; }
        public IEnumerable<AssetGatePassModel> ApproveGatePassList { get; set; }
        public IEnumerable<AssetGatePassModel> PendingGatePassList { get; set; }
        public IEnumerable<AssetGatePassModel> RejectGatepassList { get; set; }
      
    }
}
