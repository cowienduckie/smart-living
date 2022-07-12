using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DataContext _context;

        public DeviceTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.DeviceTypes.Any(d => !d.IsDelete && d.Id == id);
        }

        public IEnumerable<DeviceType> GetAll(string userId)
        {
            return _context.DeviceTypes.Where(d => !d.IsDelete).AsNoTracking().ToList();
        }

        public DeviceType GetById(int id, string userId)
        {
            return _context.DeviceTypes.FirstOrDefault(d => !d.IsDelete && d.Id == id);
        }

        public DeviceType Create(DeviceType entity, string userId)
        {
            _context.DeviceTypes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(DeviceType entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.DeviceTypes.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var device = _context.DeviceTypes.First(d => !d.IsDelete && d.Id == id);

            device.IsDelete = true;
            device.LastModified = DateTime.Now;

            _context.DeviceTypes.Update(device);
            _context.SaveChanges();
            return true;
        }
    }
}