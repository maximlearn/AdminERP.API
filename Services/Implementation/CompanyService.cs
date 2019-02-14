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

        public ResponseModel DeleteCompany(int companyId)
        {
            return this.companyRepository.DeleteCompany(companyId);
        }

        public IEnumerable<CompanyModel> GetAllCompany()
        {
            return this.companyRepository.GetAllCompany();
        }

        public CompanyModel GetCompanyById(int companyId)
        {
            return this.companyRepository.GetCompanyById(companyId);
        }

        public ResponseModel IsExist(CompanyModel companyModel)
        {
            return this.companyRepository.IsExist(companyModel);
        }

        public ResponseModel SaveCompany(CompanyModel companyModel)
        {
            return this.companyRepository.SaveCompany(companyModel);
        }
    }
}
