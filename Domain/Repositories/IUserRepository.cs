using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<RoleModel> GetRoleList();
        IEnumerable<DepartmentModel> GetDepartmentList();
        IEnumerable<UserModel> GetUserList();
        ResponseModel DeleteUser(int userId);
        ResponseModel SaveUser(UserModel user);
        UserModel GetUserDetailById(int userId);
    }
}
