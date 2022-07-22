using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLiving.Data.Repositories
{
    public class HouseTypeRepository : IHouseTypeRepository
    {
        private readonly DataContext _context;

        public HouseTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.HouseTypes.Any(h => !h.IsDelete && h.Id == id);
        }

        public IEnumerable<HouseType> GetAll(string userId)
        {
            return _context.HouseTypes.Where(h => !h.IsDelete).AsNoTracking().ToList();
        }

        public HouseType GetById(int id, string userId)
        {
            return _context.HouseTypes.FirstOrDefault(h => !h.IsDelete && h.Id == id);
        }

        public HouseType Create(HouseType entity, string userId)
        {
            _context.HouseTypes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(HouseType entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.HouseTypes.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var house = _context.HouseTypes.First(h => !h.IsDelete && h.Id == id);

            house.IsDelete = true;
            house.LastModified = DateTime.Now;

            _context.HouseTypes.Update(house);
            _context.SaveChanges();
            return true;
        }
    }
}