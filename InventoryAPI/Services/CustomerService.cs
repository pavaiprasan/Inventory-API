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
    public class CustomerService : ICustomerService
    {

        public CustomerService(){

        }
        
        public async Task<List<Customer>> GetAllCustomer(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Customer> customer = _dbContext.Customer.OrderBy(o => o.CustomerName).ToList();
            return customer;
        }  
        
        public async Task<Customer> GetCustomerById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Customer customer = _dbContext.Customer.FirstOrDefault(i => i.CustomerId == id);
            return customer;
        }

        public bool SaveCustomer(Customer customer){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            Customer dbcustomer = _dbContext.Customer.FirstOrDefault(i => i.Mobile == customer.Mobile);
            if(dbcustomer != null){
                throw new CustomerAlreadyExistsException();
            }
            else{ 
                customer.Status = 1;
                customer.CreatedOn = DateTime.Now;
                _dbContext.Customer.Add(customer);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateCustomer(Customer customer){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Customer dbcustomer = _dbContext.Customer.FirstOrDefault(i => i.CustomerId == customer.CustomerId);
            if(dbcustomer != null){                
                dbcustomer.ModifiedOn = DateTime.Now;
                dbcustomer.CustomerName = customer.CustomerName;
                dbcustomer.Mobile = customer.Mobile;
                dbcustomer.Email = customer.Email;
                dbcustomer.Address = customer.Address;
                dbcustomer.Status = customer.Status;
                dbcustomer.DiscountPercentage = customer.DiscountPercentage;
                dbcustomer.ModifiedBy = customer.ModifiedBy;
                _dbContext.SaveChanges();
            }
            else{
                return false;
            }
            return true;
        }      
    }
}
