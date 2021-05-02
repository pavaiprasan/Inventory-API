using InventoryAPI.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface ICommonService
    {
        Task<List<Menu>> GetMenuByUserId(long userId);
        Task<DaywiseCount> GetDaywiseReport(DateTime fdate, DateTime tdate);
        Task<ChartData> GetChartData(DateTime fdate, DateTime tdate);
        Task<Dashboard> GetDashboardData();
    }
}