using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Services.Interface;
using InventoryAPI.Models;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {        

        private readonly ILogger<ProductController> _logger;
        private IProductService _productservice;

        public ProductController(ILogger<ProductController> logger, IProductService productservice)
        {
            _logger = logger;
            _productservice = productservice;
        }
        
        
        [HttpGet("getallcategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            RemoteResult<List<Category>> result = new RemoteResult<List<Category>>();
            try
            {
                result.data = await _productservice.GetAllCategory();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getcategorybyid")]
        public async Task<IActionResult> GetCategoryById(long id)
        {
            RemoteResult<Category> result = new RemoteResult<Category>();
            try
            {
                result.data = await _productservice.GetCategoryById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }


        [HttpPost("savecategory")]
        public ActionResult SaveCategory([FromBody] Category category)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.SaveCategory(category);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updatecategory")]        
        public ActionResult UpdateCategory([FromBody] Category category)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.UpdateCategory(category);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        
        [HttpGet("getallsubcategory")]
        public async Task<IActionResult> GetAllSubCategory()
        {
            RemoteResult<List<SubCategory>> result = new RemoteResult<List<SubCategory>>();
            try
            {
                result.data = await _productservice.GetAllSubCategory();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getsubcategorybyid")]
        public async Task<IActionResult> GetSubCategoryById(long id)
        {
            RemoteResult<SubCategory> result = new RemoteResult<SubCategory>();
            try
            {
                result.data = await _productservice.GetSubCategoryById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getsubcategorybycategoryid")]
        public async Task<IActionResult> GetSubCategoryByCategoryId(long id)
        {
            RemoteResult<List<SubCategory>> result = new RemoteResult<List<SubCategory>>();
            try
            {
                result.data = await _productservice.GetSubCategoryByCategoryId(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("savesubcategory")]
        public ActionResult SaveSubCategory([FromBody] SubCategory subcategory)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.SaveSubCategory(subcategory);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updatesubcategory")]        
        public ActionResult UpdateSubCategory([FromBody] SubCategory subcategory)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.UpdateSubCategory(subcategory);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getallproduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            RemoteResult<List<Product>> result = new RemoteResult<List<Product>>();
            try
            {
                result.data = await _productservice.GetAllProduct();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getproductbyid")]
        public async Task<IActionResult> GetProductById(long id)
        {
            RemoteResult<Product> result = new RemoteResult<Product>();
            try
            {
                result.data = await _productservice.GetProductById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getproductbycodeorname")]
        public async Task<IActionResult> GetProductByCodeOrName(string code)
        {
            RemoteResult<List<Product>> result = new RemoteResult<List<Product>>();
            try
            {
                result.data = await _productservice.GetProductByCodeOrName(code);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("saveproduct")]
        public ActionResult SaveProduct([FromBody] Product product)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.SaveProduct(product);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updateproduct")]        
        public ActionResult UpdateProduct([FromBody] Product product)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _productservice.UpdateProduct(product);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

    }
}
