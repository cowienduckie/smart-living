using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly DataContext _context;

        public CommandRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Commands.Any(c => !c.IsDelete && c.Id == id);
        }

        public IEnumerable<Command> GetAll()
        {
            return _context.Commands.Where(c => !c.IsDelete).AsNoTracking().ToList();
        }

        public Command GetById(int id)
        {
            return _context.Commands.FirstOrDefault(c => !c.IsDelete && c.Id == id);
        }

        public Command Create(Command entity)
        {
            _context.Commands.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Command entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Commands.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var command = _context.Commands.First(c => !c.IsDelete && c.Id == id);

            command.IsDelete = true;
            command.LastModified = DateTime.Now;

            _context.Commands.Update(command);
            _context.SaveChanges();
            return true;
        }
    }
}