using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Entities;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseRepository _houseRepository;

        public HouseController(
            IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        // GET: House
        public IActionResult Index()
        {
            try
            {
                var allItems = _houseRepository.GetAll().ToList();

                return View(allItems);

            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        // GET: House/Detail/id
        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var item = _houseRepository.GetById(id);

                if (item == null)
                    item = new House();

                return View(item);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}