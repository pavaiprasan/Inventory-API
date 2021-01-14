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
    public class UserController : ControllerBase
    {        

        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userservice)
        {
            _logger = logger;
            _userService = userservice;
        }
        
        [HttpPost("authendicate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authendicate([FromBody] UserProfile user)
        {
            RemoteResult<UserProfile> result = new RemoteResult<UserProfile>();
            try
            {
                result.data = await _userService.Authendicate(user);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}
