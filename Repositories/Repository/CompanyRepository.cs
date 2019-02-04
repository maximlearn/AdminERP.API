﻿using AutoMapper;
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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public CompanyRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<CompanyModel> GetAllCompanies()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Company
                     .Where(x => x.IsActive == true).ToList();
                return modelMapper.Map<List<CompanyModel>>(Items);
            }
        }

        public CompanyModel GetCompanyById(int companyId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Company
                               .Where(p => p.Id == companyId)
                               .FirstOrDefault();
                return modelMapper.Map<CompanyModel>(Items);
            }
        }

        public ResponseModel IsExist(int Id)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                if (context.Company.Any(x => x.Id == Id))
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "Company Tag Id: " + Id + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveCompany(CompanyModel companyModel)
        {
            return companyModel.Id==0 ? AddCompany(companyModel) : UpdateCompany(companyModel);
        }

        private ResponseModel AddCompany(CompanyModel companyModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel oResponse = new ResponseModel();
                try
                {
                    Company companyEntity = new Company();
                    companyEntity.Id = companyModel.Id;
                    companyEntity.CompanyName = companyModel.CompanyName;
                    companyEntity.Address1 = companyModel.Address1;
                    companyEntity.Phone = companyModel.Phone;
                    companyEntity.Email = companyModel.Email;
                    companyEntity.Country = companyModel.Country;
                    companyEntity.IsActive = true;
                    companyEntity.CreatedBy = 1;
                    companyEntity.CreatedDate = DateTime.Now;
                    companyEntity.ModifiedBy = 1;
                    companyEntity.ModifiedDate = DateTime.Now;
                    oResponse.Message = "Company saved successfully.";
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

        private ResponseModel UpdateCompany(CompanyModel companyModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var oResponse = new ResponseModel();
                try
                {
                    var companyEntity = new Company();
                    companyEntity.Id = companyModel.Id;
                    companyEntity.CompanyName = companyModel.CompanyName;
                    companyEntity.Address1 = companyModel.Address1;
                    companyEntity.Phone = companyModel.Phone;
                    companyEntity.Email = companyModel.Email;
                    companyEntity.Country = companyModel.Country;
                    companyEntity.IsActive = true;
                    companyEntity.CreatedBy = 1;
                    companyEntity.CreatedDate = DateTime.Now;
                    companyEntity.ModifiedBy = 1;
                    companyEntity.ModifiedDate = DateTime.Now;

                    context.Update(companyEntity);
                    context.SaveChanges();
                  
                    oResponse.Message = "Company updated successfully.";
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