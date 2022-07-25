using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly DataContext _context;

        public HouseRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Houses.Any(h => !h.IsDelete && h.Id == id);
        }

        public IEnumerable<House> GetAll()
        {
            return _context.Houses
                .Where(h => !h.IsDelete)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .ThenInclude(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<House> GetAll(string userId)
        {
            var allItems = _context.Houses
                .Where(h => !h.IsDelete && h.UserId == userId)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .ThenInclude(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .AsNoTracking()
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
            return _context.Houses
                .Where(h => !h.IsDelete && h.Id == id)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .ThenInclude(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public House GetById(int id, string userId)
        {
            var item = _context.Houses
                .Where(h => !h.IsDelete && h.Id == id && h.UserId == userId)
                .Include(h => h.HouseType)
                .Include(h => h.Areas)
                .ThenInclude(a => a.Devices)
                .ThenInclude(d => d.DeviceType)
                .AsNoTracking()
                .FirstOrDefault();

            if (item != null)
            {
                item.Areas = item.Areas.Where(a => !a.IsDelete).ToList();
                item.Devices = item.Devices.Where(d => !d.IsDelete).ToList();
            }

            return item;
        }

        public House Create(House entity, string userId)
        {
            entity.UserId = userId;

            _context.Houses.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(House entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Houses.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var house = _context.Houses.First(h => !h.IsDelete && h.Id == id && h.UserId == userId);

            house.IsDelete = true;
            house.LastModified = DateTime.Now;

            _context.SaveChanges();
            return true;
        }
    }
}