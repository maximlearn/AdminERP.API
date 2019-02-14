using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class VendorService : IVendorService
    {
        public readonly IVendorRepository vendorRepository;
        public VendorService(IVendorRepository _vendorRepository)
        {
            vendorRepository = _vendorRepository;
        }

        public ResponseModel DeleteVendor(int vendorId)
        {
            return this.vendorRepository.DeleteVendor(vendorId);
        }

        //private readonly IVendorRepository vendorRepository;
        public IEnumerable<VendorModel> GetAllVendor()
        {
            return this.vendorRepository.GetAllVendor();
        }

        public VendorModel GetVendorById(int vendorId)
        {
            return this.vendorRepository.GetVendorById(vendorId);
        }

        public ResponseModel IsExist(VendorModel vendorModel)
        {
            return this.vendorRepository.IsExist(vendorModel);
        }

        public ResponseModel SaveVendor(VendorModel vendorModel)
        {
            return this.vendorRepository.SaveVendor(vendorModel);
        }
    }
}
