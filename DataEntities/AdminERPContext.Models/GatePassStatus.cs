using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class GatePassStatus
    {
        public GatePassStatus()
        {
            AssetGatePass = new HashSet<AssetGatePass>();
        }

        public int Id { get; set; }
        public string GatePassStatus1 { get; set; }

        public virtual ICollection<AssetGatePass> AssetGatePass { get; set; }
    }
}
