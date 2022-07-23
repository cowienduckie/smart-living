using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Command> GetAll(string userId)
        {
            return _context.Commands.Where(c => !c.IsDelete && c.UserId == userId).AsNoTracking().ToList();
        }

        public Command GetById(int id, string userId)
        {
            return _context.Commands.FirstOrDefault(c => !c.IsDelete && c.Id == id && c.UserId == userId);
        }

        public Command Create(Command entity, string userId)
        {
            entity.UserId = userId;

            _context.Commands.Add(entity);

            // Change Device params
            var device = _context.Devices
                .FirstOrDefault(d => !d.IsDelete && d.Id == entity.DeviceId);

            if (device != null)
            {
                var deviceParams = JObject.Parse(device.Params);
                var commandParams = JObject.Parse(entity.Params);

                deviceParams["controls"]![Convert.ToString(entity.CommandTypeId)] = commandParams;
                device.Params = deviceParams.ToString(Formatting.None);
            }

            _context.SaveChanges();
            return entity;
        }

        public bool Update(Command entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Commands.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var command = _context.Commands.First(c => !c.IsDelete && c.Id == id && c.UserId == userId);

            command.IsDelete = true;
            command.LastModified = DateTime.Now;

            _context.Commands.Update(command);
            _context.SaveChanges();
            return true;
        }
    }
}