using SmartLiving.Domain.Entities;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IHouseRepository : IBaseRepository<House>
    {
        IEnumerable<House> GetAll();

        House GetById(int id);
    }
}