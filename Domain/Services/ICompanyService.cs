using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface ICompanyService
    {
        IEnumerable<CompanyModel> GetAllCompany();
        ResponseModel SaveCompany(CompanyModel companyModel);
        CompanyModel GetCompanyById(int companyId);
        ResponseModel IsExist(CompanyModel companyModel);
        ResponseModel DeleteCompany(int companyId);

    }
}
