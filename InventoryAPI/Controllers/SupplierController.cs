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
    public class SupplierController : ControllerBase
    {        

        private readonly ILogger<SupplierController> _logger;
        private ISupplierService _supplierservice;

        public SupplierController(ILogger<SupplierController> logger, ISupplierService supplierservice)
        {
            _logger = logger;
            _supplierservice = supplierservice;
        }
        
        
        [HttpGet("getallsupplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            RemoteResult<List<Supplier>> result = new RemoteResult<List<Supplier>>();
            try
            {
                result.data = await _supplierservice.GetAllSupplier();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getsupplierbyid")]
        public async Task<IActionResult> GetSupplierById(long id)
        {
            RemoteResult<Supplier> result = new RemoteResult<Supplier>();
            try
            {
                result.data = await _supplierservice.GetSupplierById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }


        [HttpPost("savesupplier")]
        public ActionResult SaveSupplier([FromBody] Supplier supplier)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _supplierservice.SaveSupplier(supplier);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updatesupplier")]        
        public ActionResult UpdateSupplier([FromBody] Supplier supplier)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _supplierservice.UpdateSupplier(supplier);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}
