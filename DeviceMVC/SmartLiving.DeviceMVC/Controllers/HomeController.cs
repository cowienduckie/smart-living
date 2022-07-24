using System.Diagnostics;
using System.Threading;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.Services;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {

            return RedirectToAction("Index", "House");
        }
    }
}