using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class GatePassType
    {
        public GatePassType()
        {
            AssetGatePass = new HashSet<AssetGatePass>();
            AssetGatePassDetail = new HashSet<AssetGatePassDetail>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<AssetGatePass> AssetGatePass { get; set; }
        public virtual ICollection<AssetGatePassDetail> AssetGatePassDetail { get; set; }
    }
}
