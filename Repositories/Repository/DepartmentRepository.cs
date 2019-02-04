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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public DepartmentRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<DepartmentModel> GetAllDepartments()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Department
                    .Where(x => x.IsActive == true).ToList();
                return modelMapper.Map<List<DepartmentModel>>(Items);
            }
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Department
                               .Where(p => p.Id == departmentId)
                               .FirstOrDefault();
                return modelMapper.Map<DepartmentModel>(Items);
            }
        }

        public ResponseModel IsExists(int departmentId)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                if (context.Department.Any(x => x.Id == departmentId))
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "Department Id: " + departmentId + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveDepartment(DepartmentModel departmentModel)
        {
            return departmentModel.Id==0 ? AddDepartment(departmentModel) : UpdateDepartment(departmentModel);
        }

        private ResponseModel AddDepartment(DepartmentModel departmentModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel oResponse = new ResponseModel();
                try
                {
                    Department departmentEntity = new Department();
                    departmentEntity.Id = departmentModel.Id;
                    departmentEntity.DepartmentName = departmentModel.DepartmentName;
                    departmentEntity.IsActive = departmentModel.IsActive;
                    departmentEntity.CreatedBy = 1;
                    departmentEntity.CreatedDate = DateTime.Now;
                    departmentEntity.ModifiedBy = 1;
                    departmentEntity.ModifiedDate = DateTime.Now;
                    context.Add(departmentEntity);
                    context.SaveChanges();
                   
                    oResponse.Message = "Department saved successfully.";
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

        private ResponseModel UpdateDepartment(DepartmentModel departmentModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var oResponse = new ResponseModel();
                try
                {
                    var departmentEntity = new Department();
                    departmentEntity.Id = departmentModel.Id;
                    departmentEntity.DepartmentName = departmentModel.DepartmentName;
                    departmentEntity.IsActive = departmentModel.IsActive;
                    departmentEntity.CreatedBy = 1;
                    departmentEntity.CreatedDate = DateTime.Now;
                    departmentEntity.ModifiedBy = 1;
                    departmentEntity.ModifiedDate = DateTime.Now;

                    context.Update(departmentEntity);
                    context.SaveChanges();

                    oResponse.Message = "Department updated successfully.";
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