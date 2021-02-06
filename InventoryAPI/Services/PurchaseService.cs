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
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<Purchase>> GetAllPurchase(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Purchase> purchase = _dbContext.Purchase
                                     .Include(p => p.PurchaseProducts)
                                     .Include(o => o.Payment)
                                     .OrderBy(o => o.PurchaseId).ToList();
            return purchase;
        }

        public async Task<List<PaymentType>> GetPaymentType(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<PaymentType> paymentType = _dbContext.PaymentType
                                     .OrderBy(o => o.Type).ToList();
            return paymentType;
        }
    }
}
