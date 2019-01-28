using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class AssetGatePass
    {
        public AssetGatePass()
        {
            AssetGatePassDetail = new HashSet<AssetGatePassDetail>();
            AssetGatePassSenderDetail = new HashSet<AssetGatePassSenderDetail>();
        }

        public long Id { get; set; }
        public string GatePassNo { get; set; }
        public DateTime GatePassDate { get; set; }
        public int GatePassTypeId { get; set; }
        public int? ReceivedBy { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int? GatePassStatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Status GatePassStatus { get; set; }
        public virtual GatePassType GatePassType { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual User ReceivedByNavigation { get; set; }
        public virtual ICollection<AssetGatePassDetail> AssetGatePassDetail { get; set; }
        public virtual ICollection<AssetGatePassSenderDetail> AssetGatePassSenderDetail { get; set; }
    }
}
