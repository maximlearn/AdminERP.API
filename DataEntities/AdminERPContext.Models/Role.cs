using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleFunction = new HashSet<RoleFunction>();
            RoleMenu = new HashSet<RoleMenu>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<RoleFunction> RoleFunction { get; set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
