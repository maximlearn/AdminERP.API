using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AssetGatePassModel
    {
        public AssetGatePassModel()
        {

        }
        public long Id { get; set; }
        public string GatePassNo { get; set; }
        public DateTime GatePassDate { get; set; }
        public bool? IsReturnable { get; set; }
        public int GatePassStatusId { get; set; }
        public int? ReceivedBy { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        //public virtual User CreatedByNavigation { get; set; }
        //public virtual GatePassStatus GatePassStatus { get; set; }
        //public virtual User ModifiedByNavigation { get; set; }
        //public virtual User ReceivedByNavigation { get; set; }
        //public virtual ICollection<AssetGatePassDetail> AssetGatePassDetail { get; set; }
        //public virtual ICollection<AssetGatePassSenderDetail> AssetGatePassSenderDetail { get; set; }
    }
}
