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
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<RoleFunction> RoleFunction { get; set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
