using System;
using System.Collections.Generic;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.User.Any(u => !u.IsDelete && u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.Where(u => !u.IsDelete).AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(u => !u.IsDelete && u.Id == id);
        }

        public User Create(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(User entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.User.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var user = _context.Categories.First(u => !u.IsDelete && u.Id == id);

            user.IsDelete = true;
            user.LastModified = DateTime.Now;

            _context.User.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}