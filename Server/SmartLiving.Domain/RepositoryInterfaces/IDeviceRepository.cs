using SmartLiving.Domain.Entities;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        IEnumerable<Device> GetAll();

        Device GetById(int id);
    }
}