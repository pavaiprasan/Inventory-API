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
    public class CustomerController : ControllerBase
    {        

        private readonly ILogger<CustomerController> _logger;
        private ICustomerService _customerservice;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerservice)
        {
            _logger = logger;
            _customerservice = customerservice;
        }
        
        
        [HttpGet("getallcustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            RemoteResult<List<Customer>> result = new RemoteResult<List<Customer>>();
            try
            {
                result.data = await _customerservice.GetAllCustomer();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getcustomerbyid")]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            RemoteResult<Customer> result = new RemoteResult<Customer>();
            try
            {
                result.data = await _customerservice.GetCustomerById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }


        [HttpPost("savecustomer")]
        public ActionResult SaveCustomer([FromBody] Customer customer)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _customerservice.SaveCustomer(customer);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updatecustomer")]        
        public ActionResult UpdateCustomer([FromBody] Customer customer)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _customerservice.UpdateCustomer(customer);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}
