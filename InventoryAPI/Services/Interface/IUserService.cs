using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface IUserService
    {
        Task<UserProfile> Authendicate(UserProfile profile);
        Task<List<UserProfile>> GetAllUser();
        Task<UserProfile> GetUserById(long id);
        bool SaveUser(UserProfile profile);
        bool UpdateUser(UserProfile profile);

    }
}