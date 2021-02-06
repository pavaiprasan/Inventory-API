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
    public class ProductService : IProductService
    {

        public ProductService(){

        }
        
        public async Task<List<Category>> GetAllCategory(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Category> category = _dbContext.Category.OrderBy(o => o.CategoryName).ToList();
            return category;
        }  
        
        public async Task<Category> GetCategoryById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Category category = _dbContext.Category.FirstOrDefault(i => i.CategoryId == id);
            return category;
        }

        public bool SaveCategory(Category category){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            Category dbcategory = _dbContext.Category.FirstOrDefault(p => p.CategoryName == category.CategoryName);
            if(dbcategory != null){
                throw new CategoryAlreadyExistsException();
            }
            else{ 
                category.Status = 1;
                category.CreatedOn = DateTime.Now;
                _dbContext.Category.Add(category);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateCategory(Category category){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Category dbcategory = _dbContext.Category.FirstOrDefault(i => i.CategoryId == category.CategoryId);
            if(dbcategory != null){                
                dbcategory.ModifiedOn = DateTime.Now;
                dbcategory.CategoryName = category.CategoryName;
                dbcategory.Description = category.Description;                
                dbcategory.Status = category.Status;
                dbcategory.ModifiedBy = category.ModifiedBy;
                _dbContext.SaveChanges();
            }
            else{
                return false;
            }
            return true;
        }

        public async Task<List<SubCategory>> GetAllSubCategory(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<SubCategory> subcategory = _dbContext.SubCategory.Include(c => c.Category).OrderBy(o => o.SubCategoryName).ToList();
            return subcategory;
        }  
        
        public async Task<SubCategory> GetSubCategoryById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            SubCategory subcategory = _dbContext.SubCategory.Include(c => c.Category).FirstOrDefault(i => i.SubCategoryId == id);
            return subcategory;
        }

        public async Task<List<SubCategory>> GetSubCategoryByCategoryId(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<SubCategory> subcategory = _dbContext.SubCategory.Include(c => c.Category).Where(i => i.CategoryId == id).ToList();
            return subcategory;
        }

        public bool SaveSubCategory(SubCategory subcategory){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            SubCategory dbSubcategory = _dbContext.SubCategory.FirstOrDefault(i => i.SubCategoryName == subcategory.SubCategoryName && i.CategoryId == subcategory.CategoryId);
            if(dbSubcategory != null){
                throw new SubCategoryAlreadyExistsException();
            }
            else{ 
                subcategory.Status = 1;
                subcategory.CreatedOn = DateTime.Now;
                _dbContext.SubCategory.Add(subcategory);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateSubCategory(SubCategory subcategory){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            SubCategory dbsubcategory = _dbContext.SubCategory.FirstOrDefault(i => i.SubCategoryId == subcategory.SubCategoryId);
            if(dbsubcategory != null){                
                dbsubcategory.ModifiedOn = DateTime.Now;
                dbsubcategory.SubCategoryName = subcategory.SubCategoryName;
                dbsubcategory.CategoryId = subcategory.CategoryId;
                dbsubcategory.Description = subcategory.Description;
                dbsubcategory.Status = subcategory.Status;
                dbsubcategory.ModifiedBy = subcategory.ModifiedBy;
                _dbContext.SaveChanges();
            }
            else{
                return false;
            }
            return true;
        }     
         
        public async Task<List<Product>> GetAllProduct(){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Product> product = _dbContext.Product.Include(c => c.Category).Include(s => s.SubCategory).OrderBy(o => o.ProductName).ToList();
            return product;
        }  
        
        public async Task<Product> GetProductById(long id){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Product product = _dbContext.Product.Include(c => c.Category).Include(s => s.SubCategory).FirstOrDefault(i => i.ProductId == id);
            return product;
        }

        public async Task<List<Product>> GetProductByCodeOrName(string code){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            List<Product> product = _dbContext.Product.Include(c => c.Category).Include(s => s.SubCategory).Where(i => i.ProductCode == code || i.ProductName == code).ToList();
            return product;
        }

        public bool SaveProduct(Product product){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();                        
            Product dbproduct = _dbContext.Product.FirstOrDefault(i => i.ProductName == product.ProductName && i.CategoryId == product.CategoryId && i.SubCategoryId == product.SubCategoryId);
            if(dbproduct != null){
                throw new ProductAlreadyExistsException();
            }
            else{ 
                product.Status = 1;
                product.CreatedOn = DateTime.Now;
                _dbContext.Product.Add(product);              
                _dbContext.SaveChanges();                    
            }
            return true;
        }

        public bool UpdateProduct(Product product){
            using ApplicationDbContext _dbContext = new ApplicationDbContext();
            Product dbproduct = _dbContext.Product.FirstOrDefault(i => i.ProductId == product.ProductId);
            if(dbproduct != null){                
                dbproduct.ModifiedOn = DateTime.Now;
                dbproduct.ProductName = product.ProductName;
                dbproduct.ProductCode = product.ProductCode;
                dbproduct.Description = product.Description;
                //dbproduct.Category = product.Category;
                //dbproduct.SubCategory = product.SubCategory;
                dbproduct.PurchasePrice = product.PurchasePrice;
                dbproduct.SellingPrice = product.SellingPrice;
                dbproduct.Status = product.Status;
                dbproduct.ModifiedBy = product.ModifiedBy;
                _dbContext.SaveChanges();
            }
            else{
                return false;
            }
            return true;
        }
 
    }
}
