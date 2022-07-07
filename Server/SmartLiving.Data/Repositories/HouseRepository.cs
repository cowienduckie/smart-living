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
            return _context.Houses.Where(h => !h.IsDelete).AsNoTracking().ToList();
        }

        public House GetById(int id)
        {
            return _context.Houses.FirstOrDefault(h => !h.IsDelete && h.Id == id);
        }

        public House Create(House entity)
        {
            _context.Houses.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(House entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Houses.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var house = _context.Houses.First(h => !h.IsDelete && h.Id == id);

            house.IsDelete = true;
            house.LastModified = DateTime.Now;

            _context.Houses.Update(house);
            _context.SaveChanges();
            return true;
        }
    }
}