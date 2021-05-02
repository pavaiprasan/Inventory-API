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
    public class PurchaseService : IPurchaseService
    {

        public PurchaseService(){

        }               

        public bool SavePurchase(Purchase purchase){
            using ApplicationDbContext _dbContext = new ApplicationDbContext(); 
            purchase.Status = 1;
            purchase.CreatedOn = DateTime.Now;                    
            _dbContext.Purchase.Add(purchase);              
            foreach (var item in purchase.PurchaseProducts)
            {
               Product product = _dbContext.Product.FirstOrDefault(p => p.ProductId == item.ProductId);
               if(product != null){
                   product.AvailableCount = product.AvailableCount + item.Quantity;                   
               } 
            }
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<Purchase>> GetAllPurchase(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Purchase> purchase = _dbContext.Purchase
                                     .Include(s => s.Supplier)
                                     .Include(p => p.PurchaseProducts)
                                     .Include(o => o.Payment)
                                     .OrderByDescending(o => o.PurchaseId).ToList();
            return purchase;
        }

        public async Task<List<Purchase>> GetPurchaseByDate(DateTime fromdate, DateTime todate){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Purchase> purchase = _dbContext.Purchase
                                     .Include(s => s.Supplier)
                                     .Include(p => p.PurchaseProducts)
                                     .Include(o => o.Payment)
                                     .Where(c => c.PurchaseDate >= fromdate && c.PurchaseDate <= todate)
                                     .OrderByDescending(o => o.PurchaseId).ToList();
            return purchase;
        }

        public async Task<Purchase> GetPurchaseDetailsById(long purchaseId){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Purchase purchase = _dbContext.Purchase
                                     .Include(s => s.Supplier)
                                     .Include(p => p.PurchaseProducts).ThenInclude(p => p.Product)
                                     .Include(o => o.Payment).ThenInclude(o => o.PaymentType)
                                     .FirstOrDefault(o => o.PurchaseId == purchaseId);
            return purchase;
        }

        public async Task<List<PaymentType>> GetPaymentType(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<PaymentType> paymentType = _dbContext.PaymentType
                                     .OrderBy(o => o.Type).ToList();
            return paymentType;
        }

        public bool SavePayment(Payment payment){
            using ApplicationDbContext _dbContext = new ApplicationDbContext(); 
            payment.Status = 1;
            payment.CreatedOn = DateTime.Now;                    
            _dbContext.Payment.Add(payment);              
            _dbContext.SaveChanges();
            Purchase purchase = _dbContext.Purchase.FirstOrDefault(p => p.PurchaseId == payment.PurchaseId);
            purchase.BalanceAmount = purchase.BalanceAmount + payment.PaidAmount;
            purchase.ModifiedOn = DateTime.Now;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
