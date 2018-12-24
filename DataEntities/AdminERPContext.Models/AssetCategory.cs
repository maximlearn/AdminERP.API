using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AssetCategory
    {
        public AssetCategory()
        {
            Asset = new HashSet<Asset>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
    }
}
