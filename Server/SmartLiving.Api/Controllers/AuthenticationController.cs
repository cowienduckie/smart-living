using System;
using System.Threading.Tasks;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Api.Middleware;
using SmartLiving.Domain.Events;
using SmartLiving.Domain.Models;
using SmartLiving.Domain.Services;

namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInRequestModel model)
        {
            try
            {
                var response = await _userService.SignIn(model);

                if (response == null)
                    return BadRequest(new {message = "Username or password is incorrect!"});

                return Ok(response);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpRequestModel model)
        {
            try
            {
                var succeeded = await _userService.SignUp(model);

                if (!succeeded)
                    return BadRequest(new {message = "Something went wrong!"});

                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                await _userService.SignOut();
                return Ok();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}