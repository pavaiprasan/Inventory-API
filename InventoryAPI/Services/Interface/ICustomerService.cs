using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(long id);
        bool SaveCustomer(Customer supplier);
        bool UpdateCustomer(Customer supplier);
    }
}