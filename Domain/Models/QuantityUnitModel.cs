using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class QuantityUnitModel
    {
        public QuantityUnitModel()
        {
            //AssetGatePassDetailReceivedQtyUnit = new HashSet<AssetGatePassDetail>();
            //AssetGatePassDetailSendQtyUnit = new HashSet<AssetGatePassDetail>();
        }

        public int Id { get; set; }
        public string Unit { get; set; }

        //public virtual ICollection<AssetGatePassDetail> AssetGatePassDetailReceivedQtyUnit { get; set; }
        //public virtual ICollection<AssetGatePassDetail> AssetGatePassDetailSendQtyUnit { get; set; }
    }
}
