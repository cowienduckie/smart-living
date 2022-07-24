using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BusinessLogics.Configs;
using SmartLiving.DeviceMVC.BusinessLogics.DataContext;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Entities;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly Context _context;

        public HouseRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<House> GetAll()
        {
            var allItems = _context.Houses
                .Where(h => !h.IsDelete)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .Include(h => h.Devices)
                .ToList();

            allItems.ForEach(h =>
            {
                h.Areas = h.Areas.Where(a => !a.IsDelete).ToList();
                h.Devices = h.Devices.Where(d => !d.IsDelete).ToList();
            });

            return allItems;
        }

        public House GetById(int id)
        {
            var item = _context.Houses
                .Where(h => !h.IsDelete && h.Id == id)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .Include(h => h.Devices)
                .FirstOrDefault();

            if (item != null)
            {
                item.Areas = item.Areas.Where(a => !a.IsDelete).ToList();
                item.Devices = item.Devices.Where(d => !d.IsDelete).ToList();
            }

            return item;
        }
    }
}