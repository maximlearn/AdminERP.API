using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class RoleMenuModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public short ParentMenuId { get; set; }
        public short MenuId { get; set; }

        //public virtual MenuModel Menu { get; set; }
        //public virtual Role Role { get; set; }
    }
}
