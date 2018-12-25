using AutoMapper;
using DataEntities.AdminERPContext.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<AssetModel, Asset>().ReverseMap();
            CreateMap<AssetDetailModel, AssetDetail>().ReverseMap();
            CreateMap<AssetCategoryModel, AssetCategory>().ReverseMap();
        }

    }
}
