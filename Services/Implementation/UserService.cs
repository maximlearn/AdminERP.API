using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public ResponseModel DeleteUser(int userId)
        {
            return this.userRepository.DeleteUser(userId);
        }

        public IEnumerable<DepartmentModel> GetDepartmentList()
        {
            return this.userRepository.GetDepartmentList();
        }

        public IEnumerable<RoleModel> GetRoleList()
        {
            return this.userRepository.GetRoleList();
        }

        public UserModel GetUserDetailById(int userId)
        {
            return this.userRepository.GetUserDetailById(userId);
        }

        public IEnumerable<UserModel> GetUserList()
        {
            return this.userRepository.GetUserList();
        }

        public ResponseModel SaveUser(UserModel user)
        {
            return this.userRepository.SaveUser(user);
        }
    }
}
