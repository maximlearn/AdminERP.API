﻿using AutoMapper;
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
            CreateMap<VendorModel, Vendor>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<RoleMenu, RoleMenuModel>().ReverseMap();
            CreateMap<RoleFunction, RoleFunctionModel>().ReverseMap();
            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<Function, FunctionModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<UserCredential, UserCredentialModel>().ReverseMap();            
            CreateMap<UserSecurityAnswer, UserSecurityAnswerModel>().ReverseMap();
            CreateMap<AssetGatePassModel, AssetGatePass>().ReverseMap();
            CreateMap<AssetGatePassDetailModel, AssetGatePassDetail>().ReverseMap();
            CreateMap<AssetGatePassSenderDetailModel, AssetGatePassSenderDetail>().ReverseMap();
            CreateMap<GatePassTypeModel, GatePassType>().ReverseMap();
            CreateMap<StatusModel, Status>().ReverseMap();
            CreateMap<QuantityUnitModel, QuantityUnit>().ReverseMap();

        }

    }
}
