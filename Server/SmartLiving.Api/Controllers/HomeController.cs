using Microsoft.AspNetCore.Mvc;

namespace SmartLiving.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}
