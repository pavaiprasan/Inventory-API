using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(long id);
        bool SaveSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplier);
    }
}