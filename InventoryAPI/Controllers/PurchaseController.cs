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

        [HttpGet("getpaymentType")]
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
    }
}