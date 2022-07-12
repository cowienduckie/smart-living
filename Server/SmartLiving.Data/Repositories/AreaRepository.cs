using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DataContext _context;

        public AreaRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Areas.Any(a => !a.IsDelete && a.Id == id);
        }

        public IEnumerable<Area> GetAll(string userId)
        {
            return _context.Areas.Where(a => !a.IsDelete && a.House.UserId == userId).AsNoTracking().ToList();
        }

        public Area GetById(int id, string userId)
        {
            return _context.Areas.FirstOrDefault(a => !a.IsDelete && a.Id == id && a.House.UserId == userId);
        }

        public Area Create(Area entity, string userId)
        {
            _context.Areas.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Area entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Areas.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var area = _context.Areas.First(a => !a.IsDelete && a.Id == id && a.House.UserId == userId);

            area.IsDelete = true;
            area.LastModified = DateTime.Now;

            _context.Areas.Update(area);
            _context.SaveChanges();
            return true;
        }
    }
}