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
    public class SalesController : ControllerBase
    {        

        private readonly ILogger<SalesController> _logger;
        private ISalesService _salesservice;

        public SalesController(ILogger<SalesController> logger, ISalesService salesservice)
        {
            _logger = logger;
            _salesservice = salesservice;
        }

        [HttpPost("savesales")]
        public ActionResult SaveSales([FromBody] Sales sales)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _salesservice.SaveSales(sales);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getallsales")]
        public async Task<IActionResult> GetAllSales()
        {
            RemoteResult<List<Sales>> result = new RemoteResult<List<Sales>>();
            try
            {
                result.data = await _salesservice.GetAllSales();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getsalesbydate")]
        public async Task<IActionResult> GetSalesByDate(DateTime fromdate, DateTime todate)
        {
            RemoteResult<List<Sales>> result = new RemoteResult<List<Sales>>();
            try
            {
                result.data = await _salesservice.GetSalesByDate(fromdate, todate);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getsalesdetailsbyid")]
        public async Task<IActionResult> GetSalesDetailsById(long salesId)
        {
            RemoteResult<Sales> result = new RemoteResult<Sales>();
            try
            {
                result.data = await _salesservice.GetSalesDetailsById(salesId);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
        
        [HttpPost("savesalespayment")]
        public ActionResult SaveSalesPayment([FromBody] SalesPayment salespayment)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _salesservice.SaveSalesPayment(salespayment);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }    
    }
}
