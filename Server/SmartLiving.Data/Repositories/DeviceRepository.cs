using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                    .Include(d => d.House)
                        .ThenInclude(h => h.User)
                    .Include(d => d.Area)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Device GetById(int id, string userId)
        {
            return _context.Devices.FirstOrDefault(d => !d.IsDelete && d.Id == id && d.House.UserId == userId);
        }

        public Device Create(Device entity, string userId)
        {
            _context.Devices.Add(entity);

            if (entity.DeviceTypeId != 0)
            {
                entity.Params = _context.DeviceTypes.FirstOrDefault(dt => dt.Id == entity.DeviceTypeId)?.DefaultParams;
            }

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