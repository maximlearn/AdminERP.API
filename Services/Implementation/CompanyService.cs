using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository _companyRespoitory)
        {
            this.companyRepository = _companyRespoitory;
        }

        public IEnumerable<CompanyModel> GetAllCompanies()
        {
            return this.companyRepository.GetAllCompanies();
        }

        public CompanyModel GetCompanyById(int companyId)
        {
            return this.companyRepository.GetCompanyById(companyId);
        }

        public ResponseModel IsExist(int companyId)
        {
            return this.companyRepository.IsExist(companyId);
        }

        public ResponseModel SaveCompany(CompanyModel companyModel)
        {
            return this.companyRepository.SaveCompany(companyModel);
        }
    }
}
