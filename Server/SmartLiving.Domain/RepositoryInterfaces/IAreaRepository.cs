using System.Collections.Generic;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        IEnumerable<Area> GetAll();

        Area GetById(int id);
    }
}