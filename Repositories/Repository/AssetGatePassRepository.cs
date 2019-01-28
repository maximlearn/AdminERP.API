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
                var gatePassList = context.AssetGatePass
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
                       ReceivedByNavigation = p.ReceivedByNavigation,
                       CreatedByNavigation = p.CreatedByNavigation,
                       AssetGatePassDetail = p.AssetGatePassDetail.Where(x => x.AssetGatePassId == p.Id)
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
                       AssetGatePassSenderDetail = p.AssetGatePassSenderDetail.Where(x => x.AssetGatePassId == p.Id).ToList()

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
                    if (assetGatePassModel.Id > 0)
                    {
                        var gatePassDetailList = context.AssetGatePassDetail.Where(x => x.AssetGatePassId == assetGatePassModel.Id);

                        foreach (var item in gatePassDetailList)
                        {
                            //AssetGatePassDetail gatePassDetailEntity = new AssetGatePassDetail();
                            // gatePassDetailEntity.Id = item.Id;
                            context.Remove(item);

                        }
                        context.SaveChanges();
                    }
                    // end delete the existing asset Gate Pass detail from Db in case of edit

                    var statusList = context.Status.ToList();

                    AssetGatePass gatePassEntity = new AssetGatePass();
                    gatePassEntity.Id = assetGatePassModel.Id;
                    gatePassEntity.GatePassNo = assetGatePassModel.GatePassNo;
                    gatePassEntity.GatePassDate = assetGatePassModel.GatePassDate;
                    gatePassEntity.GatePassTypeId = assetGatePassModel.GatePassTypeId;
                    gatePassEntity.GatePassStatusId = statusList.Where(x => x.StatusName == "Pending").FirstOrDefault().Id;
                    gatePassEntity.ReceivedBy = 1;
                    gatePassEntity.CreatedBy = 1;
                    gatePassEntity.CreatedDate = DateTime.Now;
                    gatePassEntity.ModifiedBy = 1;
                    gatePassEntity.ModifiedDate = DateTime.Now;
                    gatePassEntity.IsActive = true;
                    gatePassEntity.Remarks = assetGatePassModel.Remarks;
                    if (assetGatePassModel.Id == 0)
                    { context.Add(gatePassEntity); }
                    else
                    { context.Update(gatePassEntity); }

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
                        objResponse.Message = "Gate Pass Created successfully.";
                    }
                    else
                    {
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
                    var gatePassSenderDetail = context.AssetGatePassSenderDetail.Where(x => x.AssetGatePassId == gatePassId).FirstOrDefault();
                    if (gatePassSenderDetail != null)
                    {
                        context.Remove<AssetGatePassSenderDetail>(gatePassSenderDetail);
                        context.SaveChanges();
                    }

                    var gatePassDetail = context.AssetGatePassDetail.Where(x => x.AssetGatePassId == gatePassId).FirstOrDefault();
                    if (gatePassDetail != null)
                    {
                        context.Remove<AssetGatePassDetail>(gatePassDetail);
                        context.SaveChanges();
                    }

                    var gatePass = context.AssetGatePass.Where(x => x.Id == gatePassId).FirstOrDefault();
                    if (gatePass != null)
                    {
                        context.Remove<AssetGatePass>(gatePass);
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
    }
}
