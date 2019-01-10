﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class SaveAssetRequestModel
    {
        public AssetModel assetData { get; set; }
        public dynamic formData { get; set; }
    }
}
