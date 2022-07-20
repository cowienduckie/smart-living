using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Entities.Models;
using System.Diagnostics;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}