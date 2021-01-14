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
    public class CommonService : ICommonService
    {
        //private readonly ApplicationDbContext _dbContext;

        public CommonService(){

        }

        public async Task<List<Menu>> GetMenuByUserId(long userId){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Menu> menu = _dbContext.Menu.Include(i => i.SubMenu).ToList();
            return menu;
        }

    }
}
