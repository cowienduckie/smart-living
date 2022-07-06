using System;
using System.Collections.Generic;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetAll()
        {
            throw new NotImplementedException();
        }

        public Schedule GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Schedule Create(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}