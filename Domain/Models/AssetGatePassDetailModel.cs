using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AssetGatePassDetailModel
    {
        public long Id { get; set; }
        public long? AssetGatePassId { get; set; }
        public long? AssetId { get; set; }
        public decimal? SendQty { get; set; }
        public int? SendQtyUnitId { get; set; }
        public decimal? ReceivedQty { get; set; }
        public int? ReceivedQtyUnitId { get; set; }
        public int? AssetTypeId { get; set; }

        public virtual AssetModel Asset { get; set; }      
        public virtual GatePassTypeModel AssetType { get; set; }
        public virtual QuantityUnitModel ReceivedQtyUnit { get; set; }
        public virtual QuantityUnitModel SendQtyUnit { get; set; }
    }
}
