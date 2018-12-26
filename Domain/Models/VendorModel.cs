using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class VendorModel
    {
        public VendorModel()
        {
            //AssetDetail = new HashSet<AssetDetail>();
        }

        public int Id { get; set; }
        public string VendorName { get; set; }
        public bool? IsActive { get; set; }

       // public virtual ICollection<AssetDetailModel> AssetDetail { get; set; }
    }
}
