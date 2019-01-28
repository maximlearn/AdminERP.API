using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class StatusModel
    {
        public StatusModel()
        {

        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        //public virtual ICollection<AssetGatePass> AssetGatePass { get; set; }
    }
}
