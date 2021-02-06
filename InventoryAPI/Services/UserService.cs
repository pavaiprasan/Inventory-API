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

        public async Task<List<UserProfile>> GetAllUser(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<UserProfile> user = _dbContext.UserProfile.Where(i => i.Status == 1).OrderBy(o => o.UserName).ToList();
            return user;
        }  

        public async Task<UserProfile> GetUserById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            UserProfile user = _dbContext.UserProfile.FirstOrDefault(i => i.UserId == id);
            return user;
        }

        public bool SaveUser(UserProfile profile){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            UserProfile user = _dbContext.UserProfile.FirstOrDefault(i => i.Mobile == profile.Mobile);
            if(user != null){
                throw new UserAlreadyExistsException();
            }
            else{ 
                profile.Status = 1;
                profile.CreatedOn = DateTime.Now;
                _dbContext.UserProfile.Add(profile);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateUser(UserProfile profile){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            UserProfile user = _dbContext.UserProfile.FirstOrDefault(i => i.UserId == profile.UserId);
            if(user == null){
                throw new UserNotFoundException();
            }
            else{
                user.ModifiedOn = DateTime.Now;
                user.UserName = profile.UserName;
                user.Mobile = profile.Mobile;
                user.Email = profile.Email;
                user.Address = profile.Address;
                user.Role = profile.Role;
                user.Status = profile.Status;
                user.ModifiedBy = profile.ModifiedBy;
                _dbContext.SaveChanges();
            }
            return true;
        }      
    }
}
