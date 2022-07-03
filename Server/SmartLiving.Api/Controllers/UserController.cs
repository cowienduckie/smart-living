using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("[action]")]
        public IActionResult Authenticate(LoginRequestModel model)
        {
            try
            {
                var response = _userService.Authenticate(model);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
