using Microsoft.AspNetCore.Mvc;
using SmartLiving.Domain.Entities;
using System;

namespace SmartLiving.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected User CurrentUser => (User)HttpContext.Items["User"];

        protected ActionResult HandleException(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e);
        }
    }
}