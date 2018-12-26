using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class AssetDetailModel
    {
        public AssetDetailModel()
        {

        }

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

        public virtual AssetModel Asset { get; set; }
        public virtual VendorModel Vendor { get; set; }

    }
}
