using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRoleModel> GetAll();
    }
}
