﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentModel> GetAllDepartments();
        ResponseModel SaveDepartment(DepartmentModel departmentModel);
        DepartmentModel GetDepartmentById(int departmentId);
    }
}
