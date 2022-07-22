using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLiving.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _context;

        public ProfileRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Profiles.Any(p => !p.IsDelete && p.Id == id);
        }

        public IEnumerable<Profile> GetAll(string userId)
        {
            return _context.Profiles.Where(p => !p.IsDelete && p.UserId == userId).AsNoTracking().ToList();
        }

        public Profile GetById(int id, string userId)
        {
            return _context.Profiles.FirstOrDefault(p => !p.IsDelete && p.Id == id && p.UserId == userId);
        }

        public Profile Create(Profile entity, string userId)
        {
            entity.UserId = userId;

            _context.Profiles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Profile entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Profiles.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var profile = _context.Profiles.First(p => !p.IsDelete && p.Id == id && p.UserId == userId);

            profile.IsDelete = true;
            profile.LastModified = DateTime.Now;

            _context.Profiles.Update(profile);
            _context.SaveChanges();
            return true;
        }
    }
}