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
    public class SalesService : ISalesService
    {

        public SalesService(){

        }               

        public bool SaveSales(Sales Sales){
            using ApplicationDbContext _dbContext = new ApplicationDbContext(); 
            Sales.Status = 1;
            Sales.CreatedOn = DateTime.Now;  
            int c = _dbContext.Sales.Count();
            Sales.SalesNumber = "sno" + c.ToString();                 
            _dbContext.Sales.Add(Sales);              
            foreach (var item in Sales.SalesProducts)
            {
               Product product = _dbContext.Product.FirstOrDefault(p => p.ProductId == item.ProductId);
               if(product != null){
                   product.AvailableCount = product.AvailableCount - item.Quantity;                   
               } 
            }
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<Sales>> GetAllSales(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Sales> sales = _dbContext.Sales
                                        .Include(s => s.Customer)
                                        .Include(p => p.SalesProducts)
                                        .Include(o => o.SalesPayment)
                                        .OrderByDescending(o => o.SalesId).ToList();
            return sales;
        }

        public async Task<List<Sales>> GetSalesByDate(DateTime fromdate, DateTime todate){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Sales> sales = _dbContext.Sales
                                        .Include(s => s.Customer)
                                        .Include(p => p.SalesProducts)
                                        .Include(o => o.SalesPayment)
                                        .Where(c => c.SalesDate >= fromdate && c.SalesDate <= todate)
                                        .OrderByDescending(o => o.SalesId).ToList();
            return sales;
        }

        public async Task<Sales> GetSalesDetailsById(long salesId){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Sales sales = _dbContext.Sales
                                     .Include(s => s.Customer)
                                     .Include(p => p.SalesProducts).ThenInclude(p => p.Product)
                                     .Include(o => o.SalesPayment).ThenInclude(o => o.PaymentType)
                                     .FirstOrDefault(o => o.SalesId == salesId);
            return sales;
        }

        public bool SaveSalesPayment(SalesPayment salesPayment){
            using ApplicationDbContext _dbContext = new ApplicationDbContext(); 
            salesPayment.Status = 1;
            salesPayment.CreatedOn = DateTime.Now;                    
            _dbContext.SalesPayment.Add(salesPayment);              
            _dbContext.SaveChanges();
            Sales sales = _dbContext.Sales.FirstOrDefault(p => p.SalesId == salesPayment.SalesId);
            sales.BalanceAmount = sales.BalanceAmount + salesPayment.PaidAmount;
            sales.ModifiedOn = DateTime.Now;
            _dbContext.SaveChanges();
            return true;
        }
    }
}