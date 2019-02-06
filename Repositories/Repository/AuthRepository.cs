using AutoMapper;
using DataEntities.AdminERPContext.Models;
using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public AuthRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }
        public UserModel Authenticate(LoginDetails userModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {

                var user = context.User.Include(x => x.UserCredential)
                    .Where(x => x.EmpId == userModel.UserId && x.UserCredential.FirstOrDefault().Password == userModel.Password).FirstOrDefault();
                return modelMapper.Map<UserModel>(user);
            }

        }
        public IEnumerable<MenuModel>GetUserRoleMenuList(int roleId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var roleMenu = context.RoleMenu.Include(x => x.Menu).Where(p => p.RoleId == roleId && p.Menu.IsDisabled == false)
                        .Select(p => new MenuModel()
                        {
                            Id = p.Menu.Id,
                            MenuLink = p.Menu.MenuLink,
                            MenuTitle = p.Menu.MenuTitle,
                            ParentMenuId = p.Menu.ParentMenuId,
                            Tag = p.Menu.Tag

                        }).ToList();
                return roleMenu;
            }
               

        }
        public IEnumerable<FunctionModel> GetUserRoleFunctionList(int roleId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var roleFunction = context.RoleFunction.Include(x => x.Function).Where(p => p.RoleId == roleId)
                        .Select(p => new FunctionModel()
                        {
                            FunctionCode = p.Function.FunctionCode,
                            FunctionName = p.Function.FunctionName
                        }).ToList();
                return roleFunction;

            }

        }
    }
}
