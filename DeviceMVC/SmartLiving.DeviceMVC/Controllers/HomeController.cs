using System.Diagnostics;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Events;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly  IEventBus _eventBus;

        public HomeController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public IActionResult Index()
        {
            var message = new DeviceGatewayMsgEvent("DeviceGateway", "Hello world!");

            _eventBus.Publish(message);

            return RedirectToAction("Index", "House");
        }
    }
}