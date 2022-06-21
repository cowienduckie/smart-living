using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.RepositoryInterfaces;

namespace SmartLiving.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAll()
        {
            throw new NotImplementedException();
        }

        public Device GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Device Create(Device entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Device entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
