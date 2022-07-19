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
                    .Include(u => u.Houses)
                        .ThenInclude(h => h.Devices)
                .AsNoTracking()
                .ToList();
        }
    }
}
