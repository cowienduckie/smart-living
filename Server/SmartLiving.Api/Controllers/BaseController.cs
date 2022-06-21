using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartLiving.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleException(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e);
        }
    }
}
