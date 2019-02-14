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
    public class VendorRepository : IVendorRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public VendorRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public ResponseModel DeleteVendor(int vendorId)
        {
            ResponseModel objResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                var vendor = context.Vendor.Where(x => x.Id == vendorId).FirstOrDefault();
                if (vendor != null)
                {
                    vendor.IsActive = false;
                    context.SaveChanges();
                }

                objResponse.Message = "Vendor Deleted successfully.";
                objResponse.IsSuccess = true;
            }
            return objResponse;
        }

        public IEnumerable<VendorModel> GetAllVendor()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Vendor
                    .Where(x => x.IsActive == true).ToList();
                return modelMapper.Map<List<VendorModel>>(Items);
            }
        }

        public VendorModel GetVendorById(int vendorId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.Vendor
                               .Where(p => p.Id == vendorId)
                               .FirstOrDefault();
                return modelMapper.Map<VendorModel>(Items);
            }
        }

        public ResponseModel IsExist(VendorModel vendorModel)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                Boolean IsExist = false;
                if (vendorModel.Id > 0)
                { IsExist = context.Vendor.Any(x => x.VendorName == vendorModel.VendorName && x.Id != vendorModel.Id); }
                else
                { IsExist = context.Vendor.Any(x => x.VendorName == vendorModel.VendorName); }

                if (IsExist)
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "Vendor Name: " + vendorModel.VendorName + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveVendor(VendorModel vendorModel)
        {
            return vendorModel.Id == 0 ? AddVendor(vendorModel) : UpdateVendor(vendorModel);
        }

        private ResponseModel AddVendor(VendorModel vendorModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel oResponse = new ResponseModel();
                try
                {
                    Vendor vendorEntity = new Vendor();
                    vendorEntity.Id = vendorModel.Id;
                    vendorEntity.VendorName = vendorModel.VendorName;
                    vendorEntity.IsActive = true;
                    vendorEntity.CreatedBy = 1;
                    vendorEntity.CreatedDate = DateTime.Now;

                    context.Add(vendorEntity);
                    context.SaveChanges();

                    oResponse.Message = "Vendor saved successfully.";
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

        private ResponseModel UpdateVendor(VendorModel vendorModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var oResponse = new ResponseModel();
                try
                {
                    var vendorEntity = new Vendor();
                    vendorEntity.Id = vendorModel.Id;
                    vendorEntity.VendorName = vendorModel.VendorName;
                    vendorEntity.IsActive = true;
                    vendorEntity.CreatedBy = 1;
                    vendorEntity.CreatedDate = vendorModel.CreatedDate;
                    vendorEntity.ModifiedBy = 1;
                    vendorEntity.ModifiedDate = DateTime.Now;

                    context.Update(vendorEntity);
                    context.SaveChanges();

                    oResponse.Message = "Vendor updated successfully.";
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