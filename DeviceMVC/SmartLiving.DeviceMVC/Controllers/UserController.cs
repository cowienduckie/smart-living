using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: User
        public IActionResult Index()
        {
            try
            {
                var allItems = _userRepository.GetAll()?.ToList() ?? new List<UserModel>();

                return View(allItems);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        // GET: User/Details/id
        [HttpGet]
        public IActionResult Details(string id)
        {
            try
            {
                var item = _userRepository.GetById(id);

                if (item == null)
                    item = new UserModel();

                return View(item);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}