using System;
using System.Collections.Generic;

namespace DataEntities.AdminERPContext.Models
{
    public partial class Function
    {
        public Function()
        {
            RoleFunction = new HashSet<RoleFunction>();
        }

        public int Id { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }

        public virtual ICollection<RoleFunction> RoleFunction { get; set; }
    }
}
