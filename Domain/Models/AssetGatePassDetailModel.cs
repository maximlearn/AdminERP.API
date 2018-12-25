﻿using System;
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
        public bool? IsReturnable { get; set; }

        //public virtual Asset Asset { get; set; }
        //public virtual AssetGatePass AssetGatePass { get; set; }
        //public virtual QuantityUnit ReceivedQtyUnit { get; set; }
        //public virtual QuantityUnit SendQtyUnit { get; set; }
    }
}
