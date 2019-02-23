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
        public int GatePassTypeId { get; set; }
        public int? ReceivedBy { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int? GatePassStatusId { get; set; }
        public string Comment { get; set; }      
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual StatusModel GatePassStatus { get; set; }
        public virtual GatePassTypeModel GatePassType { get; set; }
        public virtual UserModel  CreatedByNavigation { get; set; }
        public virtual UserModel ReceivedByNavigation { get; set; }
        public CompanyModel Company { get; set; }

        public virtual ICollection<AssetGatePassDetailModel> AssetGatePassDetail { get; set; }
        public virtual ICollection<AssetGatePassSenderDetailModel> AssetGatePassSenderDetail { get; set; }
    }
}
