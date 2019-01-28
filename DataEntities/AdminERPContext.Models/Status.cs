using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class Status
    {
        public Status()
        {
            AssetGatePass = new HashSet<AssetGatePass>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<AssetGatePass> AssetGatePass { get; set; }
    }
}
