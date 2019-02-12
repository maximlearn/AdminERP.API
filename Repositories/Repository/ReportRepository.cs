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
using System.Data;

namespace Repositories.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public ReportRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public IEnumerable<StatusModel> GetAllGatePassStatus()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var gatePassStatus = context.Status.ToList();
                return modelMapper.Map<List<StatusModel>>(gatePassStatus);
            }
        }

       



        public IEnumerable<ReportModel> GetGatePassReportWithItems()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                //var reportData = (from a in context.AssetGatePass
                //                  join b in context.AssetGatePassDetail 
                //                  on a.Id equals b.AssetGatePassId into gatePass
                //                  from c in gatePass.DefaultIfEmpty()
                //                  join d in context.Asset on c.Asset.Id equals d.Id
                //                  where b.accountId == 3
                //                  select new { a.Id, b.Id,....etc });
                
              context.Database.OpenConnection();
                IDbCommand dbCommand = context.Database.GetDbConnection().CreateCommand();
                dbCommand.CommandText = "GetGatePassReportWithItems";
                dbCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtData = new DataTable();
                using (var reader = dbCommand.ExecuteReader())
                {
                    dtData.Load(reader); // modelMapper.Map<ReportModel>(reader);
                    reader.Close();
                }
                var reportList = new List<ReportModel>();
                foreach (DataRow row in dtData.Rows)
                {
                    var reportData = new ReportModel()
                    {
                        GatePassNo = Convert.ToString(row["GatePassNo"]),
                        GatePassDate = Convert.ToString(row["GatePassDate"]),
                        SenderName = Convert.ToString(row["SenderName"]),
                        SendAddress = Convert.ToString(row["SendAddress"]),
                        GatePassStatus = Convert.ToString(row["GatePassStatus"]),
                        GatePassType = Convert.ToString(row["GatePassType"]),
                        AssetTagId = Convert.ToString(row["AssetTagId"]),
                        AssetName = Convert.ToString(row["AssetName"]),
                        AssetCategoryName = Convert.ToString(row["AssetCategoryName"]),
                        ReceivedBy = Convert.ToString(row["ReceivedBy"]),
                        CreatedBy = Convert.ToString(row["CreatedBy"]),

                    };
                    reportList.Add(reportData);
                }

                return reportList;
            }
        }

            public IEnumerable<AssetGatePassModel> GetGatePassSummaryReport()
        {
            using (var context = new AdminERPContext(connectionString))
            {
                var reportData = context.AssetGatePass.Select(p => new AssetGatePass()
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
                    AssetGatePassDetail = p.AssetGatePassDetail.Where(x => x.AssetGatePassId == p.Id)
                       .Select(t => new AssetGatePassDetail()
                       {
                           Id = t.Id,

                       }).ToList(),
                    AssetGatePassSenderDetail = p.AssetGatePassSenderDetail.Where(x => x.AssetGatePassId == p.Id).ToList()

                }).ToList();

                return modelMapper.Map<List<AssetGatePassModel>>(reportData);

            }
        }
    }
}
