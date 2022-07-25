using System.Collections.Generic;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IHouseRepository : IBaseRepository<House>
    {
        IEnumerable<House> GetAll();

        House GetById(int id);
    }
}