using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Entities.Models;
using System;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(
            IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        // GET: Device
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Device/Detail/id
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var item = _deviceRepository.GetById(id);

                if (item == null)
                    item = new DeviceModel();

                return View(item);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
