using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
   public class AuthService : IAuthService
    {
        public readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository _authRepository)
        {
            authRepository = _authRepository;
        }
        public UserModel Authenticate(LoginDetails userModel)
        {
            return authRepository.Authenticate(userModel);
        }

        public UserRoleModel GetUserRoleMenuFunctionList(int roleId)
        {
            UserRoleModel userRole = new UserRoleModel();
            userRole.RoleId = roleId;
            userRole.MenuList= authRepository.GetUserRoleMenuList(roleId);
            userRole.FunctionList = authRepository.GetUserRoleFunctionList(roleId);
            return userRole;
        }

      
    }
}
