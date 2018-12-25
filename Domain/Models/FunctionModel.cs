using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class FunctionModel
    {
        public FunctionModel()
        {

        }

        public int Id { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }

        //public virtual ICollection<RoleFunction> RoleFunction { get; set; }
    }
}
