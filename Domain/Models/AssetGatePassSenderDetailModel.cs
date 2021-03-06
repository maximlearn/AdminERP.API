﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AssetGatePassSenderDetailModel
    {
        public long Id { get; set; }
        public long AssetGatePassId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
