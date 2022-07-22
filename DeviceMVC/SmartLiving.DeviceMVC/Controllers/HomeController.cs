using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}