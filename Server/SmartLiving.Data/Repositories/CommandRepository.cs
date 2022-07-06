using System;
using System.Collections.Generic;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAll()
        {
            throw new NotImplementedException();
        }

        public Command GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Command Create(Command entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Command entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}