using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        public readonly IDashboardRepository dashboardRepository;
        public DashboardService(IDashboardRepository _dashboardRepository)
        {
            dashboardRepository = _dashboardRepository;
        }

        public DashboardModel GetDashboardData(int userId)
        {
            return this.dashboardRepository.GetDashboardData(userId);
        }
    }
}
