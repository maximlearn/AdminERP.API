using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AssetGatePassDetail
    {
        public long Id { get; set; }
        public long? AssetGatePassId { get; set; }
        public long? AssetId { get; set; }
        public decimal? SendQty { get; set; }
        public int? SendQtyUnitId { get; set; }
        public decimal? ReceivedQty { get; set; }
        public int? ReceivedQtyUnitId { get; set; }
        public int? AssetTypeId { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual AssetGatePass AssetGatePass { get; set; }
        public virtual GatePassType AssetType { get; set; }
        public virtual QuantityUnit ReceivedQtyUnit { get; set; }
        public virtual QuantityUnit SendQtyUnit { get; set; }
    }
}
