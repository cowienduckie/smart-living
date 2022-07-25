using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Devices.Any(d => !d.IsDelete && d.Id == id);
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices
                .Where(d => !d.IsDelete)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Device> GetAll(string userId)
        {
            return _context.Devices
                .Where(d => !d.IsDelete && d.House.UserId == userId)
                .Include(d => d.DeviceType)
                .Include(d => d.House)
                .ThenInclude(h => h.HouseType)
                .Include(d => d.Area)
                .AsNoTracking()
                .ToList();
        }

        public Device GetById(int id)
        {
            return _context.Devices
                .Where(d => !d.IsDelete && d.Id == id)
                .Include(d => d.DeviceType)
                .Include(d => d.House)
                .ThenInclude(h => h.HouseType)
                .Include(d => d.Area)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Device GetById(int id, string userId)
        {
            return _context.Devices
                .Where(d => !d.IsDelete && d.Id == id && d.House.UserId == userId)
                .Include(d => d.DeviceType)
                .Include(d => d.House)
                .ThenInclude(h => h.HouseType)
                .Include(d => d.Area)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Device Create(Device entity, string userId)
        {
            if (entity.DeviceTypeId != 0)
            {
                var deviceType = _context.DeviceTypes
                    .Where(dt => dt.Id == entity.DeviceTypeId)
                    .Include(dt => dt.DeviceTypeCommandTypes)
                    .ThenInclude(dt => dt.CommandType)
                    .FirstOrDefault();
                if (deviceType != null)
                {
                    var paramJson = JObject.Parse(deviceType.DefaultParams);
                    var controls = new JObject();

                    entity.DeviceCommandTypes = new List<DeviceCommandType>();

                    deviceType.DeviceTypeCommandTypes
                        .ToList()
                        .ForEach(dtct =>
                        {
                            controls.Add(Convert.ToString(dtct.CommandType.Id),
                                JObject.Parse(dtct.CommandType.DefaultParams));

                            entity.DeviceCommandTypes.Add(new DeviceCommandType {CommandType = dtct.CommandType});
                        });

                    paramJson["controls"] = controls;
                    entity.Params = paramJson.ToString(Formatting.None);
                }
            }

            _context.Devices.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Update(Device entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Devices.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var device = _context.Devices.First(d => !d.IsDelete && d.Id == id && d.House.UserId == userId);

            device.IsDelete = true;
            device.LastModified = DateTime.Now;

            _context.Devices.Update(device);
            _context.SaveChanges();
            return true;
        }
    }
}