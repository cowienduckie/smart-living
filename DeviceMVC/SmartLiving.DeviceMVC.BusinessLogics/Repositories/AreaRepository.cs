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
    public class AreaRepository : IAreaRepository
    {
        private readonly Context _context;

        public AreaRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Area> GetAll()
        {
            var allItems = _context.Areas
                .Where(a => !a.IsDelete)
                .Include(a => a.House)
                .ThenInclude(h => h.HouseType)
                .Include(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .ToList();

            allItems.ForEach(a =>
            {
                a.Devices = a.Devices.Where(d => !d.IsDelete).ToList();
            });

            return allItems;
        }

        public Area GetById(int id)
        {
            var item = _context.Areas
                .Where(a => !a.IsDelete && a.Id == id)
                .Include(a => a.House)
                .ThenInclude(h => h.HouseType)
                .Include(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .FirstOrDefault();

            if (item != null)
            {
                item.Devices = item.Devices.Where(d => !d.IsDelete).ToList();
            }

            return item;
        }

        public Area CreateArea(Area entity)
        {
            _context.Areas.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}