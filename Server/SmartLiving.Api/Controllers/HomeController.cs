using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartLiving.Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            try
            {
                var uri = new Uri("/swagger", UriKind.Relative);
                return Redirect(uri.ToString());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}