using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartLiving.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .Where(u => !u.IsDelete)
                .AsNoTracking()
                .ToList();
        }

        public User GetById(string id)
        {
            return _context.Users
                .Where(u => !u.IsDelete && u.Id == id)
                .Include(u => u.Houses)
                    .ThenInclude(h => h.HouseType)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public bool IsExist(string id)
        {
            return _context.Users.Any(u => !u.IsDelete && u.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
