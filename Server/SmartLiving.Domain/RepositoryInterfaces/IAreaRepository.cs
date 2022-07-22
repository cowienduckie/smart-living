using SmartLiving.Domain.Entities;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        IEnumerable<Area> GetAll();
        Area GetById(int id);
    }
}