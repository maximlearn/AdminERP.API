using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntities.AdminERPContext.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetDetail = new HashSet<AssetDetail>();
            AssetGatePassDetail = new HashSet<AssetGatePassDetail>();
        }

        public long Id { get; set; }
        public string AssetTagId { get; set; }
        public string AssetName { get; set; }
        public int AssetCategoryId { get; set; }
        public string AssetDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual AssetCategory AssetCategory { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<AssetDetail> AssetDetail { get; set; }
        public virtual ICollection<AssetGatePassDetail> AssetGatePassDetail { get; set; }
    }
}
