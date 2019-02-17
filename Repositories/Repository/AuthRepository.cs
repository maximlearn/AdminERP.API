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
       
    }
}
