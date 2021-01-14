using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface ICommonService
    {
        Task<List<Menu>> GetMenuByUserId(long userId);
    }
}