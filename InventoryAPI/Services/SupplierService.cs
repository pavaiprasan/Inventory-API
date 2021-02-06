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
    public class SupplierService : ISupplierService
    {

        public SupplierService(){

        }
        
        public async Task<List<Supplier>> GetAllSupplier(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Supplier> supplier = _dbContext.Supplier.OrderBy(o => o.SupplierName).ToList();
            return supplier;
        }  
        
        public async Task<Supplier> GetSupplierById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Supplier supplier = _dbContext.Supplier.FirstOrDefault(i => i.SupplierId == id);
            return supplier;
        }

        public bool SaveSupplier(Supplier supplier){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            Supplier dbsupplier = _dbContext.Supplier.FirstOrDefault(i => i.Mobile == supplier.Mobile);
            if(dbsupplier != null){
                throw new SupplierAlreadyExistsException();
            }
            else{ 
                supplier.Status = 1;
                supplier.CreatedOn = DateTime.Now;
                _dbContext.Supplier.Add(supplier);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateSupplier(Supplier supplier){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Supplier dbsupplier = _dbContext.Supplier.FirstOrDefault(i => i.SupplierId == supplier.SupplierId);
            if(dbsupplier != null){                
                dbsupplier.ModifiedOn = DateTime.Now;
                dbsupplier.SupplierName = supplier.SupplierName;
                dbsupplier.CompanyName = supplier.CompanyName;
                dbsupplier.Mobile = supplier.Mobile;
                dbsupplier.Email = supplier.Email;
                dbsupplier.Address = supplier.Address;
                dbsupplier.Status = supplier.Status;
                dbsupplier.ModifiedBy = supplier.ModifiedBy;
                _dbContext.SaveChanges();
            }
            else{
                return false;
            }
            return true;
        }      
    }
}
