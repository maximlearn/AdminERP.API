using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class AssetCategoryModel
    {
        public AssetCategoryModel()
        {     
        
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }

    }
}
