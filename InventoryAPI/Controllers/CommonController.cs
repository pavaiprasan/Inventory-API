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
    public class CommonController : ControllerBase
    {        

        private readonly ILogger<CommonController> _logger;
        private ICommonService _commonService;

        public CommonController(ILogger<CommonController> logger, ICommonService commonservice)
        {
            _logger = logger;
            _commonService = commonservice;
        }
        
        [HttpGet("getmenubyuserid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMenuByUserId(long userId)
        {
            RemoteResult<List<Menu>> result = new RemoteResult<List<Menu>>();
            try
            {
                result.data = await _commonService.GetMenuByUserId(userId);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}
