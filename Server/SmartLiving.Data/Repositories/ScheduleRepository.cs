using System;
using System.Collections.Generic;
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
            return _context.Schedule.Any(s => !s.IsDelete && s.Id == id);
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _context.Schedule.Where(s => !s.IsDelete).AsNoTracking().ToList();
        }

        public Schedule GetById(int id)
        {
            return _context.Schedule.FirstOrDefault(s => !s.IsDelete && s.Id == id);
        }

        public Schedule Create(Schedule entity)
        {
            _context.Schedule.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Update(Schedule entity)
        {
            if (!IsExist(entity.Id)) return false;

            entity.LastModified = DateTime.Now;

            _context.Schedule.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;

            var schedule = _context.Categories.First(s => !s.IsDelete && s.Id == id);

            schedule.IsDelete = true;
            schedule.LastModified = DateTime.Now;

            _context.Schedule.Update(schedule);
            _context.SaveChanges();
            return true;
        }
    }
}