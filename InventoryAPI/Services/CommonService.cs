using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Entity;
using InventoryAPI.Services.Interface;
using InventoryAPI.Models;
using InventoryAPI.Helper.Custom;

namespace InventoryAPI.Service
{
    public class CommonService : ICommonService
    {
        //private readonly ApplicationDbContext _dbContext;

        public CommonService(){

        }

        public async Task<List<Menu>> GetMenuByUserId(long userId){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Menu> menu = _dbContext.Menu.Include(i => i.SubMenu).OrderBy(o => o.Order).ToList();
            return menu;
        }

        public async Task<DaywiseCount> GetDaywiseReport(DateTime fdate, DateTime tdate){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            DaywiseCount daywisecount = new DaywiseCount();
            var purchase = _dbContext.PurchaseProducts
                                        .Where(i => i.CreatedOn >= fdate && i.CreatedOn <= tdate)
                                        .Select(o => o.TotalPrice);
            var sales = _dbContext.SalesProducts
                                        .Where(i => i.CreatedOn >= fdate && i.CreatedOn <= tdate)
                                        .Select(o => o.TotalPrice);
            daywisecount.PurchasedCount = purchase.Count();
            daywisecount.PurchasedPrice = purchase.Sum();
            daywisecount.SaleCount = sales.Count();
            daywisecount.SalePrice = sales.Sum();                                        
            return daywisecount;
        }

        public async Task<ChartData> GetChartData(DateTime fdate, DateTime tdate){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            ChartData chartdata = new ChartData();
            List<CData> purchase = _dbContext.Purchase
                                        .Where(i => i.CreatedOn >= fdate && i.CreatedOn <= tdate)
                                        .GroupBy(x=>x.CreatedOn.Value.Date)
                                        .Select(x=> new CData
                                        {
                                            Amount = x.Sum(d => d.TotalAmount),
                                            Date = (DateTime)x.Key // or x.Key.Date (excluding time info) or x.Key.Date.ToString() (give only Date in string format) 
                                        })
                                        .ToList();
            List<CData> sales = _dbContext.Sales
                                        .Where(i => i.CreatedOn >= fdate && i.CreatedOn <= tdate)
                                        .GroupBy(x=>x.CreatedOn.Value.Date)
                                        .Select(x=> new CData
                                        {
                                            Amount = x.Sum(d => d.TotalAmount),
                                            Date = (DateTime)x.Key // or x.Key.Date (excluding time info) or x.Key.Date.ToString() (give only Date in string format) 
                                        })
                                        .ToList();
            chartdata.Purchase = purchase;
            chartdata.Sales = sales;
            return chartdata;
        }
        
        public async Task<Dashboard> GetDashboardData(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Dashboard dashboarddata = new Dashboard();
            var c = _dbContext.Customer.Where(c => c.Status == 1).Count();
            var p = _dbContext.Product.Where(p => p.Status == 1).Count();
            var s = _dbContext.Supplier.Where(s => s.Status == 1).Count();
            var u = _dbContext.UserProfile.Where(u => u.Status == 1).Count();

            dashboarddata.CustomerCount = c;
            dashboarddata.ProductCount = p;
            dashboarddata.SupplierCount = s;
            dashboarddata.UserCount = u;
            return dashboarddata;
        }

    }
}
