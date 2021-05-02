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
    public class PurchaseController : ControllerBase
    {        

        private readonly ILogger<PurchaseController> _logger;
        private IPurchaseService _purchaseservice;

        public PurchaseController(ILogger<PurchaseController> logger, IPurchaseService purchaseservice)
        {
            _logger = logger;
            _purchaseservice = purchaseservice;
        }

        [HttpPost("savepurchase")]
        public ActionResult SavePurchase([FromBody] Purchase purchase)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _purchaseservice.SavePurchase(purchase);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getallpurchase")]
        public async Task<IActionResult> GetAllPurchase()
        {
            RemoteResult<List<Purchase>> result = new RemoteResult<List<Purchase>>();
            try
            {
                result.data = await _purchaseservice.GetAllPurchase();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getpurchasebydate")]
        public async Task<IActionResult> GetPurchaseByDate(DateTime fromdate, DateTime todate)
        {
            RemoteResult<List<Purchase>> result = new RemoteResult<List<Purchase>>();
            try
            {
                result.data = await _purchaseservice.GetPurchaseByDate(fromdate, todate);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getpurchasedetailsbyid")]
        public async Task<IActionResult> GetPurchaseDetailsById(long purchaseId)
        {
            RemoteResult<Purchase> result = new RemoteResult<Purchase>();
            try
            {
                result.data = await _purchaseservice.GetPurchaseDetailsById(purchaseId);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getpaymenttype")]
        public async Task<IActionResult> GetPaymentType()
        {
            RemoteResult<List<PaymentType>> result = new RemoteResult<List<PaymentType>>();
            try
            {
                result.data = await _purchaseservice.GetPaymentType();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("savepayment")]
        public ActionResult SavePayment([FromBody] Payment payment)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _purchaseservice.SavePayment(payment);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}