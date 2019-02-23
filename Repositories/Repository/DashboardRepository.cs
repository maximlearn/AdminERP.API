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
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IConnectionString connectionString;
        private readonly ITargetDbContext targetDbContext;
        private readonly IMapper modelMapper;
        public DashboardRepository(IConnectionString _connectionString, ITargetDbContext _targetDbContext, IMapper _modelMapper)
        {
            connectionString = _connectionString;
            targetDbContext = _targetDbContext;
            modelMapper = _modelMapper;
        }

        public DashboardModel GetDashboardData(int userId)
        {
            DashboardModel dashboardModel = new DashboardModel();
            using (var context = new AdminERPContext(connectionString))
            {
                dashboardModel.PendingGatePass = context.AssetGatePass.Where(x => x.GatePassStatus.StatusName == "Pending" && x.IsActive==true).Count();
                dashboardModel.RejectGatepass = context.AssetGatePass.Where(x => x.GatePassStatus.StatusName == "Reject" && x.IsActive == true).Count();
                dashboardModel.ApproveGatePass = context.AssetGatePass.Where(x=>x.GatePassStatus.StatusName == "Approved" && x.IsActive == true).Count();
                dashboardModel.PendingGatePassList = context.AssetGatePass.Where(x => x.GatePassStatus.StatusName == "Pending" && x.IsActive == true).Select(
                     x => new AssetGatePassModel()
                     {
                         Id = x.Id,
                         GatePassNo = x.GatePassNo
                     }).OrderByDescending(x=>x.Id).Take(5).ToList();
                dashboardModel.ApproveGatePassList = context.AssetGatePass.Where(x => x.GatePassStatus.StatusName == "Approved" && x.IsActive == true).Select(
                     x => new AssetGatePassModel()
                     {
                         Id = x.Id,
                         GatePassNo = x.GatePassNo
                     }).OrderByDescending(x => x.Id).Take(5).ToList();
                dashboardModel.RejectGatepassList = context.AssetGatePass.Where(x => x.GatePassStatus.StatusName == "Reject" && x.IsActive == true).Select(
                     x => new AssetGatePassModel()
                     {
                         Id = x.Id,
                         GatePassNo = x.GatePassNo
                     }).OrderByDescending(x => x.Id).Take(5).ToList();


               
            }
            return dashboardModel;
        }

       
    }
}