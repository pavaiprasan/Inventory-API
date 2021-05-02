using InventoryAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Models;

namespace InventoryAPI.Services.Interface
{
    public interface IProductService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategoryById(long id);
        bool SaveCategory(Category category);
        bool UpdateCategory(Category category);

        Task<List<SubCategory>> GetAllSubCategory();
        Task<SubCategory> GetSubCategoryById(long id);
        Task<List<SubCategory>> GetSubCategoryByCategoryId(long id);
        bool SaveSubCategory(SubCategory subcategory);
        bool UpdateSubCategory(SubCategory subcategory);

        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(long id);
        Task<Product> GetProductByCodeOrName(string code);
        bool SaveProduct(Product product);
        bool UpdateProduct(Product product);
    }
}