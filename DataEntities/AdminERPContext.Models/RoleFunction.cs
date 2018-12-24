using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class RoleFunction
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
        public bool IsActive { get; set; }

        public virtual Function Function { get; set; }
        public virtual Role Role { get; set; }
    }
}
