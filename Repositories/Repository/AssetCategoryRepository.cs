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
    public class AssetCategoryRepository : IAssetCategoryRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public AssetCategoryRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<AssetCategoryModel> GetAllCategories()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context.AssetCategory
                            .Where(x => x.IsActive == true).ToList();
                return modelMapper.Map<List<AssetCategoryModel>>(Items);
            }
        }

        public AssetCategoryModel GetAssetCategoryById(int Id)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var Items = context
                               .AssetCategory.Include(x => x.Id)
                               .Where(p => p.Id == Id)
                               .FirstOrDefault();
                return modelMapper.Map<AssetCategoryModel>(Items);
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

        public ResponseModel IsExist(int Id)
        {
            ResponseModel oResponse = new ResponseModel();
            using (var context = new AdminERPContext(connectionString))
            {
                if (context.AssetCategory.Any(x => x.Id == Id))
                {
                    oResponse.IsExist = true;
                    oResponse.IsSuccess = false;
                    oResponse.Message = "AssetCategory Id: " + Id + " is already exist in the system.";
                }
            }
            return oResponse;
        }

        public ResponseModel SaveAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            return assetCategoryModel.Id==0 ? AddAssetCategory(assetCategoryModel) : UpdateAssetCategory(assetCategoryModel);
        }

        private ResponseModel AddAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel oResponse = new ResponseModel();
                try
                {
                    AssetCategory assetCategoryEntity = new AssetCategory();
                    assetCategoryEntity.Id = assetCategoryModel.Id;
                    assetCategoryEntity.CategoryName = assetCategoryModel.CategoryName;
                    assetCategoryEntity.CreatedBy = 1;
                    assetCategoryEntity.CreatedDate = DateTime.Now;
                    assetCategoryEntity.ModifiedBy = 1;
                    assetCategoryEntity.ModifiedDate = DateTime.Now;
                    assetCategoryEntity.IsActive = true;
                    context.Add(assetCategoryEntity);
                    context.SaveChanges();
                    oResponse.Message = "AssetCategory saved successfully.";
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

        private ResponseModel UpdateAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var oResponse = new ResponseModel();
                try
                {
                    var assetCategoryEntity = new AssetCategory();
                    assetCategoryEntity.Id = assetCategoryModel.Id;
                    assetCategoryEntity.CategoryName = assetCategoryModel.CategoryName;
                    assetCategoryEntity.CreatedBy = 1;
                    assetCategoryEntity.CreatedDate = DateTime.Now;
                    assetCategoryEntity.ModifiedBy = 1;
                    assetCategoryEntity.ModifiedDate = DateTime.Now;
                    assetCategoryEntity.IsActive = true;
                    context.Update(assetCategoryEntity);
                    context.SaveChanges();
                    
                    oResponse.Message = "AssetCategory updated successfully.";
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