using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class AssetCategoryModel
    {
        public AssetCategoryModel()
        {

        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // public virtual ICollection<AssetModel> Asset { get; set; }
    }
}
