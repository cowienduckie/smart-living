using System;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class AreaController : BaseController
    {
        private readonly IAreaRepository _areaRepository;

        public AreaController(
            IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        // GET: Area
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Area/Detail/id
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var item = _areaRepository.GetById(id);

                if (item == null)
                    item = new AreaModel();

                return View(item);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}