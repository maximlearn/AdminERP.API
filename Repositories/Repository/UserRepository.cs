using AutoMapper;
using DataEntities.AdminERPContext.Models;
using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public UserRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public ResponseModel DeleteUser(int userId)
        {
            ResponseModel objResponse = new ResponseModel();
            try
            {
                using (var context = new AdminERPContext(connectionString))
                {
                    var user = context.User.Where(x => x.Id == userId).FirstOrDefault();
                    if (user != null)
                    {
                        user.IsActive = false;
                        context.SaveChanges();
                    }

                    objResponse.Message = "User Deleted successfully.";
                    objResponse.IsSuccess = true;

                }
            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
                objResponse.IsSuccess = false;
            }

            return objResponse;
        }

        public IEnumerable<DepartmentModel> GetDepartmentList()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var deptList = context.Department;
                return modelMapper.Map<List<DepartmentModel>>(deptList);
            }
        }

        public IEnumerable<RoleModel> GetRoleList()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var roleList = context.Role;
                return modelMapper.Map<List<RoleModel>>(roleList);
            }
        }

        public UserModel GetUserDetailById(int userId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var userDetail = context.User.Include(x => x.Role).Include(x => x.Dept).Where(x => x.Id == userId);
                return modelMapper.Map<UserModel>(userDetail);
            }
        }
        public IEnumerable<UserModel> GetUserList()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var userDetail = context.User.Include(x => x.Role).Include(x => x.Dept).Where(x => x.IsActive == true);
                return modelMapper.Map<IEnumerable<UserModel>>(userDetail);
            }
        }

        public ResponseModel SaveUser(UserModel user)
        {
            ResponseModel objResponse = new ResponseModel();
            try
            {

                using (var context = new AdminERPContext(connectionString))
                {
                    User userEntity = new User();

                    userEntity.FirstName = user.FirstName;
                    userEntity.LastName = user.LastName;
                    userEntity.Phone = user.Phone;
                    userEntity.Email = user.Email;
                    userEntity.EmpId = user.EmpId;
                    userEntity.DeptId = user.DeptId;
                    userEntity.RoleId = user.RoleId;


                    userEntity.IsActive = true;
                    if (user.Id == 0)
                    {
                        userEntity.CreatedBy = 1;
                        userEntity.CreatedDate = DateTime.Now;
                        context.Add(userEntity);
                        context.SaveChanges();
                        int userId = userEntity.Id;
                        UserCredential userCredentialEntity = new UserCredential();
                        userCredentialEntity.UserId = userId;
                        userCredentialEntity.Password = "India123";
                        userCredentialEntity.PasswordKey = "abc";
                        userCredentialEntity.Attempted =0;
                        context.Add(userCredentialEntity);
                        context.SaveChanges();
                        objResponse.Message = "User Added successfully.";

                    }
                    else
                    {
                        userEntity.Id = user.Id;
                        userEntity.CreatedBy = user.CreatedBy;
                        userEntity.CreatedDate = user.CreatedDate;
                        userEntity.ModifiedBy = 1;
                        userEntity.ModifiedDate = DateTime.Now;
                        context.Update(userEntity);
                        context.SaveChanges();
                        objResponse.Message = "User Updated successfully.";

                    }

                    objResponse.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
                objResponse.IsSuccess = false;
            }

            return objResponse;
        }
    }
}
