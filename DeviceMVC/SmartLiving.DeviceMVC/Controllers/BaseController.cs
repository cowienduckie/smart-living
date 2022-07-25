using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult HandleException(Exception e)
        {
            Console.WriteLine(e);

            return RedirectToAction("Index", "Home");
        }
    }
}