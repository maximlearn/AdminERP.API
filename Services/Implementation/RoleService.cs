using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }

        public ResponseModel DeleteRole(int roleId)
        {
            return this.roleRepository.DeleteRole(roleId);
        }

        public IEnumerable<FunctionModel> GetRoleFunctionList(int roleId)
        {
            return this.roleRepository.GetRoleFunctionList(roleId);
        }

        public IEnumerable<MenuModel> GetRoleMenuList(int roleId)
        {
            return this.roleRepository.GetRoleMenuList(roleId);
        }

        
        public IEnumerable<RoleModel> GetAllRole()
        {
            return this.roleRepository.GetAllRole();
        }

        public RoleModel GetRoleById(int roleId)
        {
            return this.roleRepository.GetRoleById(roleId);
        }

        public ResponseModel IsExist(RoleModel roleModel)
        {
            return this.roleRepository.IsExist(roleModel);
        }

        public ResponseModel SaveRole(RoleModel roleModel)
        {
            return this.roleRepository.SaveRole(roleModel);
        }

        public UserRoleModel GetUserRoleMenuFunctionList(int roleId)
        {
            UserRoleModel userRole = new UserRoleModel();
            userRole.RoleId = roleId;
            userRole.MenuList = roleRepository.GetRoleMenuList(roleId);
            userRole.FunctionList = roleRepository.GetRoleFunctionList(roleId);
            return userRole;
        }
    }
}
