﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<CompanyModel> GetAllCompanies();
        ResponseModel SaveCompany(CompanyModel companyModel);
        CompanyModel GetCompanyById(int companyId);
        ResponseModel IsExist(int Id);
    }
}
