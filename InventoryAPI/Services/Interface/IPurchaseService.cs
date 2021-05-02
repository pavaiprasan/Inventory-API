using InventoryAPI.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface IPurchaseService
    {        
        bool SavePurchase(Purchase purchase);
        Task<List<Purchase>> GetAllPurchase();
        Task<List<Purchase>> GetPurchaseByDate(DateTime fromdate, DateTime todate);
        Task<Purchase> GetPurchaseDetailsById(long purchaseId);
        Task<List<PaymentType>> GetPaymentType();
        bool SavePayment(Payment payment);
    }
}