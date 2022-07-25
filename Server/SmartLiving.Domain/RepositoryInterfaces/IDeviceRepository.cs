using System.Collections.Generic;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        IEnumerable<Device> GetAll();

        Device GetById(int id);
    }
}