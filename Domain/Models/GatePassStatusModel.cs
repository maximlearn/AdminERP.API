using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class GatePassStatusModel
    {
        public GatePassStatusModel()
        {

        }

        public int Id { get; set; }
        public string GatePassStatus1 { get; set; }

        //public virtual ICollection<AssetGatePass> AssetGatePass { get; set; }
    }
}
