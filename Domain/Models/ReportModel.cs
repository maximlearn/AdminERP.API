using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class ReportModel
    {
        public string GatePassNo { get; set; }
        public string GatePassDate { get; set; }
        public string SenderName { get; set; }
        public string SendAddress { get; set; }     
        public string Remarks { get; set; }
        public string GatePassStatus { get; set; }
        public string GatePassType { get; set; }
        public string AssetTagId { get; set; }
        public string AssetName { get; set; }
        public string AssetCategoryName { get; set; }
        public string ReceivedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
