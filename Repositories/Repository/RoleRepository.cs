using AutoMapper;
using DataEntities.AdminERPContext.Models;
using System.Linq;
using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public RoleRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public ResponseModel DeleteRole(int roleId)
        {
            ResponseModel objResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                if (roleId > 0)
                {
                    var roleMenuList = context.RoleMenu.Where(x => x.RoleId == roleId);

                    foreach (var item in roleMenuList)
                    {
                        context.Remove(item);
                    }
                    context.SaveChanges();
                }
                var role = context.Role.Where(x => x.Id == roleId).FirstOrDefault();
                if (role != null)
                {
                    role.IsActive = false;
                    //context.Add(role);
                    context.Remove(role);
                    context.SaveChanges();
                }

                objResponse.Message = "Role Deleted successfully.";
                objResponse.IsSuccess = true;
            }
            return objResponse;
        }

        public IEnumerable<RoleModel> GetAllRole()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                // var Items = context.Role.Include(x => x.RoleMenu).Include(x => x.RoleFunction).ToList();
                var Items = context.Role.Select(
                     p => new Role()
                     {
                         Id = p.Id,
                         RoleName = p.RoleName,
                         RoleDescription = p.RoleDescription,
                         RoleMenu = p.RoleMenu.Where(x => x.RoleId == p.Id).ToList(),
                         RoleFunction = p.RoleFunction.Where(x => x.RoleId == p.Id).ToList(),
                         CreatedBy = p.CreatedBy,
                         CreatedDate = p.CreatedDate,
                         ModifiedBy = p.ModifiedBy,
                         ModifiedDate = p.ModifiedDate
                        
                     }
                    );
                return modelMapper.Map<List<RoleModel>>(Items);
            }
        }

        public IEnumerable<MenuModel> GetRoleMenuList(int roleId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                IEnumerable<Menu> roleMenu;
                if (roleId > 0)
                {
                    roleMenu = context.RoleMenu.Include(x => x.Menu).Where(p => p.RoleId == roleId && p.Menu.IsDisabled == false)
                             .Select(p => new Menu()
                             {
                                 Id = p.Menu.Id,
                                 MenuLink = p.Menu.MenuLink,
                                 MenuTitle = p.Menu.MenuTitle,
                                 ParentMenuId = p.Menu.ParentMenuId,
                                 Tag = p.Menu.Tag

                             }).ToList();
                }
                else
                {
                    roleMenu = context.Menu
                    .Where(x => x.IsDisabled == false).Select(
                          p => new Menu()
                          {
                              Id = p.Id,
                              MenuLink = p.MenuLink,
                              MenuTitle = p.MenuTitle,
                              ParentMenuId = p.ParentMenuId,
                              Tag = p.Tag

                          }).ToList();

                }
                return modelMapper.Map<List<MenuModel>>(roleMenu);

            }


        }

        //public IEnumerable<MenuModel> GetAllMenuList()
        //{
        //    using (var context = new AdminERPContext(connectionString))
        //    {
        //        var Items = context.Menu
        //            .Where(x => x.IsDisabled == false).Select(
        //                  p => new MenuModel()
        //                  {
        //                      Id = p.Id,
        //                      ParentMenuId = p.ParentMenuId,
        //                      MenuTitle = p.MenuTitle,

        //                  }).ToList();
        //        return modelMapper.Map<List<MenuModel>>(Items);
        //    }
        //}

        public IEnumerable<FunctionModel> GetRoleFunctionList(int roleId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                IEnumerable<Function> roleFunction;
                if (roleId > 0)
                {
                    roleFunction = context.RoleFunction.Include(x => x.Function).Where(p => p.RoleId == roleId)
                           .Select(p => new Function()
                           {
                               FunctionCode = p.Function.FunctionCode,
                               FunctionName = p.Function.FunctionName
                           }).ToList();
                }
                else
                {
                    roleFunction = context.Function
                       .Select(
                              p => new Function()
                              {
                                  Id = p.Id,
                                  FunctionCode = p.FunctionCode,
                                  FunctionName = p.FunctionName,

                              }).ToList();
                }
                return modelMapper.Map<IEnumerable<FunctionModel>>(roleFunction);
            }
           
        }

        public RoleModel GetRoleById(int roleId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Role.Include(x => x.RoleMenu).Include(x => x.RoleFunction)
                               .Where(p => p.Id == roleId)
                               .FirstOrDefault();
                return modelMapper.Map<RoleModel>(Items);
            }
        }

        public ResponseModel IsExist(RoleModel roleModel)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                Boolean IsExist = false;
                if (roleModel.Id > 0)
                { IsExist = context.Role.Any(x => x.RoleName == roleModel.RoleName && x.Id != roleModel.Id); }
                else
                { IsExist = context.Role.Any(x => x.RoleName == roleModel.RoleName); }

                if (IsExist)
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "Role Name: " + roleModel.RoleName + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveRole(RoleModel roleModel)
        {
            return roleModel.Id == 0 ? AddRole(roleModel) : UpdateRole(roleModel);
        }

        private ResponseModel AddRole(RoleModel roleModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel oResponse = new ResponseModel();
                try
                {
                    Role roleEntity = new Role();
                    roleEntity.Id = roleModel.Id;
                    roleEntity.RoleName = roleModel.RoleName;
                    roleEntity.RoleDescription = roleModel.RoleName;
                    roleEntity.CreatedBy = 1;
                    roleEntity.CreatedDate = DateTime.Now;

                    context.Add(roleEntity);
                    context.SaveChanges();
                    int roleId = roleEntity.Id;
                    foreach (var item in roleModel.RoleMenu)
                    {
                        RoleMenu roleMenuEntity = new RoleMenu();
                        roleMenuEntity.RoleId = roleId;
                        roleMenuEntity.MenuId = item.MenuId;
                        context.Add(roleMenuEntity);
                        context.SaveChanges();
                    }

                    oResponse.Message = "Role saved successfully.";
                    oResponse.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    oResponse.Message = ex.Message;
                    oResponse.IsSuccess = false;
                }
                return oResponse;
            }
        }

        private ResponseModel UpdateRole(RoleModel roleModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var oResponse = new ResponseModel();
                try
                {
                    if (roleModel.Id > 0)
                    {
                        var roleMenuList = context.RoleMenu.Where(x => x.RoleId == roleModel.Id);

                        foreach (var item in roleMenuList)
                        {
                            context.Remove(item);
                        }
                        context.SaveChanges();
                    }

                    var roleEntity = new Role();
                    roleEntity.Id = roleModel.Id;
                    roleEntity.RoleName = roleModel.RoleName;
                    roleEntity.RoleDescription = roleModel.RoleName;
                    //roleEntity.IsActive = true;
                    roleEntity.CreatedBy = roleModel.CreatedBy;
                    roleEntity.CreatedDate = roleModel.CreatedDate;
                    roleEntity.ModifiedBy = 1;
                    roleEntity.ModifiedDate = DateTime.Now;
                    context.Update(roleEntity);
                    context.SaveChanges();

                    foreach (var item in roleModel.RoleMenu)
                    {
                        RoleMenu roleMenuEntity = new RoleMenu();
                        roleMenuEntity.RoleId = roleModel.Id;
                        roleMenuEntity.MenuId = item.MenuId;
                        context.Add(roleMenuEntity);
                        context.SaveChanges();
                    }


                    oResponse.Message = "Role updated successfully.";
                    oResponse.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    oResponse.Message = ex.Message;
                    oResponse.IsSuccess = false;
                }
                return oResponse;
            }
        }
    }
}