using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AssetDetail
    {
        public long Id { get; set; }
        public long AssetId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? VendorId { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? WarrantyExpireDate { get; set; }
        public long? WarrantyDocumentId { get; set; }
        public string BrandName { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }

        public virtual Asset Asset { get; set; }
        
        public virtual Vendor Vendor { get; set; }
    }
}
