using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IVendorService
    {
        IEnumerable<VendorModel> GetAll();
    }
}
