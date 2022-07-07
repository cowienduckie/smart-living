using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class CommandTypeRepository : ICommandTypeRepository
    {
        private readonly DataContext _context;

        public CommandTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.CommandTypes.Any(c => !c.IsDelete && c.Id == id);
        }

        public IEnumerable<CommandType> GetAll()
        {
            return _context.CommandTypes.Where(c => !c.IsDelete).AsNoTracking().ToList();
        }

        public CommandType GetById(int id)
        {
            return _context.CommandTypes.FirstOrDefault(c => !c.IsDelete && c.Id == id);
        }

        public CommandType Create(CommandType entity)
        {
            _context.CommandTypes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(CommandType entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.CommandTypes.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var command = _context.CommandTypes.First(c => !c.IsDelete && c.Id == id);

            command.IsDelete = true;
            command.LastModified = DateTime.Now;

            _context.CommandTypes.Update(command);
            _context.SaveChanges();
            return true;
        }
    }
}