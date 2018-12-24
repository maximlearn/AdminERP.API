using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            AssetDetail = new HashSet<AssetDetail>();
        }

        public int Id { get; set; }
        public string VendorName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<AssetDetail> AssetDetail { get; set; }
    }
}
