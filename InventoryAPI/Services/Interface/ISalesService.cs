using InventoryAPI.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface ISalesService
    {        
        bool SaveSales(Sales purchase);
        Task<List<Sales>> GetAllSales();
        Task<List<Sales>> GetSalesByDate(DateTime fromdate, DateTime todate);
        Task<Sales> GetSalesDetailsById(long salesId);
        bool SaveSalesPayment(SalesPayment salespayment);
    }
}