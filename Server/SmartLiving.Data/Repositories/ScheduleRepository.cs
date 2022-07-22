using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool IsExist(int id)
        {
            return _context.Schedules.Any(s => !s.IsDelete && s.Id == id);
        }

        public IEnumerable<Schedule> GetAll(string userId)
        {
            return _context.Schedules.Where(s => !s.IsDelete && s.UserId == userId).AsNoTracking().ToList();
        }

        public Schedule GetById(int id, string userId)
        {
            return _context.Schedules.FirstOrDefault(s => !s.IsDelete && s.Id == id && s.UserId == userId);
        }

        public Schedule Create(Schedule entity, string userId)
        {
            entity.UserId = userId;

            _context.Schedules.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Schedule entity, string userId)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Schedules.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id, string userId)
        {
            if (!IsExist(id)) return false;

            var schedule = _context.Schedules.First(s => !s.IsDelete && s.Id == id && s.UserId == userId);

            schedule.IsDelete = true;
            schedule.LastModified = DateTime.Now;

            _context.Schedules.Update(schedule);
            _context.SaveChanges();
            return true;
        }
    }
}