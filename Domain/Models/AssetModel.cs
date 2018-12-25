using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public  class AssetModel
    {
        public AssetModel()
        {

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

        public virtual AssetCategoryModel AssetCategory { get; set; }
        public virtual ICollection<AssetDetailModel> AssetDetail { get; set; }
       // public virtual ICollection<AssetGatePassDetail> AssetGatePassDetail { get; set; }
    }
}
