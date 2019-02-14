using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<CompanyModel> GetAllCompany();
        ResponseModel SaveCompany(CompanyModel companyModel);
        CompanyModel GetCompanyById(int companyId);
        ResponseModel IsExist(CompanyModel companyModel);
        ResponseModel DeleteCompany(int companyId);
    }
}
