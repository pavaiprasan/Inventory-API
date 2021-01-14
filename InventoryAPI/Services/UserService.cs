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
    public class UserService : IUserService
    {
        //private readonly ApplicationDbContext _dbContext;

        public UserService(){

        }

        public async Task<UserProfile> Authendicate(UserProfile profile){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            UserProfile user = _dbContext.UserProfile.FirstOrDefault(i => i.Mobile == profile.Mobile && i.Password == profile.Password);

            if(user == null){
                throw new UserNotFoundException();
            }
            else{
                user.Token = "Token";
                await _dbContext.SaveChangesAsync();
                return user;
            }
        }

    }
}
