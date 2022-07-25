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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly Context _context;

        public DeviceRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices
                .Where(d => !d.IsDelete)
                .Include(d => d.DeviceType)
                .Include(d => d.House)
                .Include(d => d.Area)
                .ToList();
        }

        public Device GetById(int id)
        {
            return _context.Devices
                .Where(d => !d.IsDelete && d.Id == id)
                .Include(d => d.DeviceType)
                .Include(d => d.House)
                .Include(d => d.Area)
                .FirstOrDefault();
        }

        public bool Switch(int id)
        {
            var device = _context.Devices
                .FirstOrDefault(d => !d.IsDelete && d.Id == id);

            if (device == null) return false;

            device.IsActive = !device.IsActive;

            var deviceParams = JObject.Parse(device.Params);
            deviceParams["switch"] = device.IsActive;

            device.Params = deviceParams.ToString(Formatting.None);
            device.LastModified = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

        public Device CreateDevice(Device entity)
        {
            _context.Devices.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Device UpdateParams(int deviceId, JObject deviceParams)
        {
            var item = _context.Devices
                .FirstOrDefault(d => !d.IsDelete && d.Id == deviceId);

            if (item != null)
            {
                item.Params = deviceParams.ToString(Formatting.None);
                item.LastModified = DateTime.Now;
                _context.SaveChanges();
            }

            return item;
        }
    }
}