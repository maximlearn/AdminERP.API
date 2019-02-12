using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        public readonly IDepartmentRepository deptRepository;
        public DepartmentService(IDepartmentRepository _deptRepository)
        {
            deptRepository = _deptRepository;
        }

        public ResponseModel DeleteDepartment(int departmentId)
        {
            return this.deptRepository.DeleteDepartment(departmentId);
        }

        //private readonly IDepartmentRepository departmentRepository;
        public IEnumerable<DepartmentModel> GetAllDepartments()
        {
            return this.deptRepository.GetAllDepartments();
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            return this.deptRepository.GetDepartmentById(departmentId);
        }

        public ResponseModel IsExist(DepartmentModel departmentModel)
        {
            return this.deptRepository.IsExist(departmentModel);
        }

        public ResponseModel SaveDepartment(DepartmentModel departmentModel)
        {
            return this.deptRepository.SaveDepartment(departmentModel);
        }
    }
}
