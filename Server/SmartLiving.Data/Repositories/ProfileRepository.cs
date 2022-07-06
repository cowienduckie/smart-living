using System;
using System.Collections.Generic;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Profile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Profile Create(Profile entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Profile entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}