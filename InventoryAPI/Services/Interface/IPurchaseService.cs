using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface IPurchaseService
    {        
        bool SavePurchase(Purchase purchase);
        Task<List<Purchase>> GetAllPurchase();
        Task<List<PaymentType>> GetPaymentType();
    }
}