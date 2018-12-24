using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class QuantityUnit
    {
        public QuantityUnit()
        {
            AssetGatePassDetailReceivedQtyUnit = new HashSet<AssetGatePassDetail>();
            AssetGatePassDetailSendQtyUnit = new HashSet<AssetGatePassDetail>();
        }

        public int Id { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<AssetGatePassDetail> AssetGatePassDetailReceivedQtyUnit { get; set; }
        public virtual ICollection<AssetGatePassDetail> AssetGatePassDetailSendQtyUnit { get; set; }
    }
}
