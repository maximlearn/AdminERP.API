using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAllDepartments();
        ResponseModel SaveDepartment(DepartmentModel departmentModel);
        DepartmentModel GetDepartmentById(int departmentId);
        ResponseModel IsExist(DepartmentModel departmentModel);
        ResponseModel DeleteDepartment(int departmentId);
    }
}
