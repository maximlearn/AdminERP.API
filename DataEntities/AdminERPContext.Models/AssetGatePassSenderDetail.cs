using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AssetGatePassSenderDetail
    {
        public long Id { get; set; }
        public long AssetGatePassId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual AssetGatePass AssetGatePass { get; set; }
    }
}
