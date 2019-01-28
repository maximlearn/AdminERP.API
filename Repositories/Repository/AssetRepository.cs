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
    public class AssetRepository : IAssetRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public AssetRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<AssetModel> GetAllAsset()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var assetItems = context
                                    .Asset.Include(x => x.AssetCategory)
                                    .Include(x => x.AssetDetail)
                                    .ThenInclude(y => y.Vendor);
                return modelMapper.Map<List<AssetModel>>(assetItems);
            }
        }

        public AssetModel GetAssetById(int assetId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var assetItems = context
                               .Asset.Include(x => x.AssetCategory)
                               .Include(x => x.AssetDetail)
                               .ThenInclude(y => y.Vendor)
                               .Where(p => p.Id == assetId)
                               .FirstOrDefault();
                return modelMapper.Map<AssetModel>(assetItems);
            }
        }

        public IEnumerable<AssetCategoryModel> GetAllAssetCategory()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var assetCategoryItems = context.AssetCategory.Where(x => x.IsActive == true).ToList(); ;
                return modelMapper.Map<List<AssetCategoryModel>>(assetCategoryItems);
            }
        }

        public IEnumerable<VendorModel> GetAllVendor()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var assetCategoryItems = context.Vendor.Where(x => x.IsActive == true).ToList(); ;
                return modelMapper.Map<List<VendorModel>>(assetCategoryItems);
            }
        }

        public ResponseModel IsAssetExist(string AssetTagId)
        {
            ResponseModel objResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                if (context.Asset.Any(x => x.AssetTagId == AssetTagId))
                {
                    objResponse.IsExist = true;
                    objResponse.IsSuccess = false;
                    objResponse.Message = "Asset Tag Id: " + AssetTagId + " is already exist in the system.";
                }
            }

            return objResponse;
        }

        public ResponseModel SaveAsset(AssetModel assetModel)
        {
            return AddAsset(assetModel);
        }

        private ResponseModel AddAsset(AssetModel assetModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel objResponse = new ResponseModel();
                try
                {

                    Asset assetEntity = new Asset();
                    assetEntity.AssetTagId = assetModel.AssetTagId;
                    assetEntity.AssetCategoryId = assetModel.AssetCategoryId;
                    assetEntity.AssetName = assetModel.AssetName;
                    assetEntity.AssetDescription = assetModel.AssetDescription;
                    assetEntity.CreatedBy = 1;
                    assetEntity.CreatedDate = DateTime.Now;
                    assetEntity.ModifiedBy = 1;
                    assetEntity.ModifiedDate = DateTime.Now;
                    assetEntity.IsActive = true;
                    context.Add(assetEntity);
                    context.SaveChanges();
                    Int64 assetId = assetEntity.Id;
                    assetModel.Id = assetEntity.Id;
                    AssetDetail assetDetailEntity = new AssetDetail();
                    assetDetailEntity.AssetId = assetId;
                    assetDetailEntity.BrandName = assetModel.AssetDetail.FirstOrDefault().BrandName;
                    assetDetailEntity.ModelNumber = assetModel.AssetDetail.FirstOrDefault().ModelNumber;
                    assetDetailEntity.SerialNumber = assetModel.AssetDetail.FirstOrDefault().SerialNumber;
                    assetDetailEntity.Cost = assetModel.AssetDetail.FirstOrDefault().Cost;
                    assetDetailEntity.VendorId = (assetModel.AssetDetail.FirstOrDefault().VendorId != 0) ? assetModel.AssetDetail.FirstOrDefault().VendorId : null;
                    assetDetailEntity.PurchaseDate = assetModel.AssetDetail.FirstOrDefault().PurchaseDate; ;
                    assetDetailEntity.WarrantyExpireDate = assetModel.AssetDetail.FirstOrDefault().WarrantyExpireDate;
                    assetDetailEntity.WarrantyDocumentId = assetModel.AssetDetail.FirstOrDefault().WarrantyDocumentId;
                    assetDetailEntity.AssetImageId = assetModel.AssetDetail.FirstOrDefault().AssetImageId;
                    context.Add(assetDetailEntity);
                    context.SaveChanges();
                    assetModel.AssetDetail.FirstOrDefault().Id = assetDetailEntity.Id;
                    assetModel.AssetDetail.FirstOrDefault().AssetId = assetModel.Id;
                    objResponse.Message = "Asset saved successfully.";
                    objResponse.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objResponse.Message = ex.Message;
                    objResponse.IsSuccess = false;
                }
                return objResponse;
            }

        }

        public IEnumerable<AssetModel> GetAllAssetTag()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var assetTagList = context.Asset
                    .Select(p => new Asset()
                    {
                        Id = p.Id ,
                        AssetTagId = p.AssetTagId,
                        AssetName = p.AssetName,
                        CreatedDate= p.CreatedDate,
                        ModifiedDate= p.ModifiedDate,
                        AssetDetail =  p.AssetDetail.Where(x=> x.AssetId==p.Id).ToList()
                    }).ToList();

                return  modelMapper.Map<IEnumerable<AssetModel>>(assetTagList);
            }
        }
    }
}
