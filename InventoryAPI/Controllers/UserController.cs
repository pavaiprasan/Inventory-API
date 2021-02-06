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

        [HttpGet("getalluser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUser()
        {
            RemoteResult<List<UserProfile>> result = new RemoteResult<List<UserProfile>>();
            try
            {
                result.data = await _userService.GetAllUser();
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpGet("getuserbyid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserById(long id)
        {
            RemoteResult<UserProfile> result = new RemoteResult<UserProfile>();
            try
            {
                result.data = await _userService.GetUserById(id);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("saveuser")]
        [AllowAnonymous]
        public ActionResult SaveUser([FromBody] UserProfile user)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _userService.SaveUser(user);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }

        [HttpPost("updateuser")]
        [AllowAnonymous]
        public ActionResult UpdateUser([FromBody] UserProfile user)
        {
            RemoteResult<bool> result = new RemoteResult<bool>();
            try
            {
                result.data = _userService.UpdateUser(user);
            }
            catch(Exception ex)
            {
                result.SetError(ex);
            }
            return Ok(result);
        }
    }
}
