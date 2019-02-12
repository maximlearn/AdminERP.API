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

        public ResponseModel DeleteDepartment(int departmentId)
        {
            ResponseModel objResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                var department = context.Department.Where(x => x.Id == departmentId).FirstOrDefault();
                if (department != null)
                {
                    department.IsActive = false;
                    context.SaveChanges();
                }

                objResponse.Message = "Department Deleted successfully.";
                objResponse.IsSuccess = true;
            }
            return objResponse;
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

        public ResponseModel IsExist(DepartmentModel departmentModel)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                Boolean IsExist = false;
                if (departmentModel.Id > 0)
                { IsExist = context.Department.Any(x => x.DepartmentName == departmentModel.DepartmentName && x.Id != departmentModel.Id); }
                else
                { IsExist = context.Department.Any(x => x.DepartmentName == departmentModel.DepartmentName); }

                if (IsExist)
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "Department Name: " + departmentModel.DepartmentName + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveDepartment(DepartmentModel departmentModel)
        {
            return departmentModel.Id == 0 ? AddDepartment(departmentModel) : UpdateDepartment(departmentModel);
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
                    departmentEntity.IsActive = true;
                    departmentEntity.CreatedBy = 1;
                    departmentEntity.CreatedDate = DateTime.Now;

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
                    departmentEntity.IsActive = true;
                    departmentEntity.CreatedBy = 1;
                    departmentEntity.CreatedDate = departmentModel.CreatedDate;
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