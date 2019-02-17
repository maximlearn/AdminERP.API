using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }  
        public IEnumerable<RoleMenuModel> RoleMenu { get; set; }
        public IEnumerable<RoleFunctionModel> RoleFunction { get; set; }
        public IEnumerable<FunctionModel>FunctionList { get; set; }
        public IEnumerable<MenuModel> MenuList { get; set; }
    }
}
