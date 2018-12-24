using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public short MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Role Role { get; set; }
    }
}
