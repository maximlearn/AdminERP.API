using AutoMapper;
using DataEntities.AdminERPContext.Models;
using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository
{
    public class AssetGatePassRepository : IAssetGatePassRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public AssetGatePassRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<AssetGatePassModel> GetAllAssetGatePassList()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var gatePassList = context.AssetGatePass.Where(x=>x.IsActive == true)
                   .Select(p => new AssetGatePass()
                   {
                       Id = p.Id,
                       GatePassNo = p.GatePassNo,
                       GatePassDate = p.GatePassDate,
                       GatePassStatus = p.GatePassStatus,
                       GatePassType = p.GatePassType,
                       Remarks = p.Remarks,
                       CreatedDate = p.CreatedDate,
                       ModifiedDate = p.ModifiedDate,
                       CreatedBy = p.CreatedBy,
                       ModifiedBy = p.ModifiedBy,
                       ReceivedByNavigation = p.ReceivedByNavigation,
                       CreatedByNavigation = p.CreatedByNavigation,
                       AssetGatePassDetail = p.AssetGatePassDetail.Where(x => x.AssetGatePassId == p.Id).ToList(),

                   }).ToList();
                return modelMapper.Map<IEnumerable<AssetGatePassModel>>(gatePassList);
            }
        }

        public IEnumerable<GatePassTypeModel> GetAllGatePassType()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var gatePassType = context.GatePassType.ToList();
                return modelMapper.Map<IEnumerable<GatePassTypeModel>>(gatePassType);
            }
        }

       
        public AssetGatePassModel GetGatePassDetailById(int gatePassId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var gatePassDetail = context.AssetGatePass
                    .Where(x => x.Id == gatePassId && x.IsActive == true)
                   .Select(p => new AssetGatePass()
                   {
                       Id = p.Id,
                       GatePassNo = p.GatePassNo,
                       GatePassDate = p.GatePassDate,
                       GatePassStatus = p.GatePassStatus,
                       GatePassType = p.GatePassType,
                       GatePassStatusId = p.GatePassStatusId,
                       GatePassTypeId = p.GatePassTypeId,
                       Remarks = p.Remarks,
                       CreatedDate = p.CreatedDate,
                       ModifiedDate = p.ModifiedDate,
                       CreatedBy = p.CreatedBy,
                       ModifiedBy = p.ModifiedBy,
                       ReceivedByNavigation = p.ReceivedByNavigation,
                       CreatedByNavigation = p.CreatedByNavigation,
                       AssetGatePassDetail = p.AssetGatePassDetail.Where(x => x.AssetGatePassId == gatePassId)
                       .Select(t => new AssetGatePassDetail()
                       {
                           Id = t.Id,
                           AssetGatePassId = t.AssetGatePassId,
                           AssetId = t.AssetId,
                           SendQty = t.SendQty,
                           AssetTypeId = t.AssetTypeId,
                           ReceivedQty = t.ReceivedQty,
                           SendQtyUnitId = t.SendQtyUnitId,
                           Asset = t.Asset.AssetGatePassDetail
                                   .Where(x => x.Asset.Id == t.AssetId)
                                   .Select(f => new Asset()
                                   {
                                       Id = f.Asset.Id,
                                       CreatedDate = f.Asset.CreatedDate,
                                       ModifiedDate = f.Asset.ModifiedDate,
                                       AssetTagId = f.Asset.AssetTagId,
                                       AssetName = f.Asset.AssetName,
                                       AssetDetail = f.Asset.AssetDetail
                                   }
                               ).FirstOrDefault(),
                           AssetType = t.AssetType,
                           SendQtyUnit = t.SendQtyUnit
                       }
                       ).ToList(),
                       AssetGatePassSenderDetail = p.AssetGatePassSenderDetail.Where(x => x.AssetGatePassId == gatePassId).ToList()

                   }).FirstOrDefault();
                var gatePassDetailModel = modelMapper.Map<AssetGatePassModel>(gatePassDetail);
                var company = context.Company.Where(x => x.IsActive == true).FirstOrDefault();
                gatePassDetailModel.Company = modelMapper.Map<CompanyModel>(company);

                return gatePassDetailModel;


            }
        }

        public IEnumerable<QuantityUnitModel> GetAllUnit()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var uniltList = context.QuantityUnit.ToList();
                return modelMapper.Map<List<QuantityUnitModel>>(uniltList);
            }
        }

        public ResponseModel SaveAssetGatePass(AssetGatePassModel assetGatePassModel)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel objResponse = new ResponseModel();
                try
                {
                    // start delete the existing asset Gate Pass detail from Db in case of edit
                    string maxGatePassNo = string.Empty;
                    if (assetGatePassModel.Id > 0)
                    {
                        var gatePassDetailList = context.AssetGatePassDetail.Where(x => x.AssetGatePassId == assetGatePassModel.Id);

                        foreach (var item in gatePassDetailList)
                        {                           
                            context.Remove(item);
                        }
                        context.SaveChanges();
                    }
                    // end delete the existing asset Gate Pass detail from Db in case of edit

                    var statusList = context.Status.ToList();
                    // ID = ((int?)context.AssetGatePass.Max(x => (int?)x.Id) ?? 0) + 1;
                   
                    AssetGatePass gatePassEntity = new AssetGatePass();
                    if (assetGatePassModel.Id == 0)
                    {
                        maxGatePassNo = "GP-" + Convert.ToString(((int?)context.AssetGatePass.Max(x => (int?)x.Id) ?? 0) + 1);
                        gatePassEntity.GatePassNo = maxGatePassNo;//assetGatePassModel.GatePassNo;
                    }
                    else
                    {
                        gatePassEntity.GatePassNo = assetGatePassModel.GatePassNo;
                    }

                  
                    gatePassEntity.GatePassDate = assetGatePassModel.GatePassDate;
                    gatePassEntity.GatePassTypeId = assetGatePassModel.GatePassTypeId;
                    gatePassEntity.GatePassStatusId = statusList.Where(x => x.StatusName == "Pending").FirstOrDefault().Id;
                    gatePassEntity.ReceivedBy = 1;
                    gatePassEntity.IsActive = true;
                    gatePassEntity.Remarks = assetGatePassModel.Remarks;
                    if (assetGatePassModel.Id == 0)
                    {
                        gatePassEntity.CreatedBy = assetGatePassModel.CreatedBy;
                        gatePassEntity.CreatedDate = DateTime.Now;
                        context.Add(gatePassEntity);
                    }
                    else
                    {
                        gatePassEntity.Id = assetGatePassModel.Id;
                        gatePassEntity.CreatedBy = assetGatePassModel.CreatedBy;
                        gatePassEntity.CreatedDate = assetGatePassModel.CreatedDate;
                        gatePassEntity.ModifiedBy = 1;
                        gatePassEntity.ModifiedDate = DateTime.Now;
                        context.Update(gatePassEntity);
                    }

                    context.SaveChanges();

                    Int64 gatePassId = (assetGatePassModel.Id == 0) ? gatePassEntity.Id : assetGatePassModel.Id;



                    foreach (var item in assetGatePassModel.AssetGatePassDetail)
                    {
                        AssetGatePassDetail gatePassDetailEntity = new AssetGatePassDetail();
                        gatePassDetailEntity.AssetGatePassId = gatePassId;
                        gatePassDetailEntity.AssetId = item.Asset.Id;
                        gatePassDetailEntity.SendQty = item.SendQty;
                        gatePassDetailEntity.ReceivedQty = item.ReceivedQty;
                        gatePassDetailEntity.SendQtyUnitId = item.SendQtyUnitId;
                        gatePassDetailEntity.AssetTypeId = item.AssetTypeId;
                        context.Add(gatePassDetailEntity);
                        context.SaveChanges();
                    }

                    AssetGatePassSenderDetail gatePassSenderDetail = new AssetGatePassSenderDetail();                   
                    gatePassSenderDetail.AssetGatePassId = gatePassId;
                    gatePassSenderDetail.Name = assetGatePassModel.AssetGatePassSenderDetail.FirstOrDefault().Name;
                    gatePassSenderDetail.Phone = assetGatePassModel.AssetGatePassSenderDetail.FirstOrDefault().Phone;
                    gatePassSenderDetail.Address = assetGatePassModel.AssetGatePassSenderDetail.FirstOrDefault().Address;
                    gatePassSenderDetail.CompanyName = assetGatePassModel.AssetGatePassSenderDetail.FirstOrDefault().CompanyName;

                    if (assetGatePassModel.Id == 0)
                    {
                        context.Add(gatePassSenderDetail);
                        objResponse.GatePassNo = maxGatePassNo;
                        objResponse.Message = "Gate Pass Created successfully.";
                    }
                    else
                    {
                        gatePassSenderDetail.Id = assetGatePassModel.AssetGatePassSenderDetail.FirstOrDefault().Id;
                        context.Update(gatePassSenderDetail);
                        objResponse.Message = "Gate Pass Updated successfully.";
                    }

                    context.SaveChanges();
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

        public ResponseModel DeleteAssetGatePass(int gatePassId)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel objResponse = new ResponseModel();
                try
                {                  

                    var gatePass = context.AssetGatePass.Where(x => x.Id == gatePassId).FirstOrDefault();
                    if (gatePass != null)
                    {
                        gatePass.IsActive = false;
                        // context.Remove<AssetGatePass>(gatePass);
                        context.Update(gatePass);
                        context.SaveChanges();
                    }
                    objResponse.Message = "Gate Pass Deleted successfully.";
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

        public ResponseModel UpdateGatePassStatus(AssetGatePassModel assetGatePass)
        {
            using (var context = new AdminERPContext(connectionString))
            {
                ResponseModel objResponse = new ResponseModel();
                try
                {

                    var gatePass = context.AssetGatePass.Where(x => x.Id == assetGatePass.Id).FirstOrDefault();
                    var gatePassStausId = context.Status.Where(x => x.StatusName == assetGatePass.GatePassStatus.StatusName).FirstOrDefault().Id;
                    if (gatePass != null)
                    {
                        gatePass.GatePassStatusId = gatePassStausId;
                        gatePass.Comment = assetGatePass.Comment;
                        // context.Remove<AssetGatePass>(gatePass);
                        context.Update(gatePass);
                        context.SaveChanges();
                    }
                    objResponse.Message = "Gate Pass " + assetGatePass.GatePassStatus.StatusName +  " successfully.";
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
    }
}
