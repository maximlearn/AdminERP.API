using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<MenuModel> MenuList { get; set; }
        public IEnumerable<FunctionModel> FunctionList { get; set; }
    }
}
