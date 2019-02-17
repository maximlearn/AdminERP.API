using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleModel> GetAllRole();
        ResponseModel SaveRole(RoleModel roleModel);
        RoleModel GetRoleById(int roleId);
        ResponseModel IsExist(RoleModel roleModel);
        ResponseModel DeleteRole(int roleId);
        IEnumerable<MenuModel> GetRoleMenuList(int roleId);
        IEnumerable<FunctionModel> GetRoleFunctionList(int roleId);
        UserRoleModel GetUserRoleMenuFunctionList(int roleId);
    }
}
