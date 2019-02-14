﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IVendorService
    {
        IEnumerable<VendorModel> GetAllVendor();
        ResponseModel SaveVendor(VendorModel vendorModel);
        VendorModel GetVendorById(int vendorId);
        ResponseModel IsExist(VendorModel vendorModel);
        ResponseModel DeleteVendor(int vendorId);
    }
}
