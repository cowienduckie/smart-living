using System;
using System.Collections.Generic;
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
            return _context.Area.Any(a => !a.IsDelete && a.Id == id);
        }

        public IEnumerable<Area> GetAll()
        {
            return _context.Area.Where(a => !a.IsDelete).AsNoTracking().ToList();
        }

        public Area GetById(int id)
        {
            return _context.Area.FirstOrDefault(a => !a.IsDelete && a.Id == id);
        }

        public Area Create(Area entity)
        {
            _context.Area.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Area entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Area.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var area = _context.Categories.First(a => !a.IsDelete && a.Id == id);

            area.IsDelete = true;
            area.LastModified = DateTime.Now;

            _context.Area.Update(area);
            _context.SaveChanges();
            return true;
        }
    }
}