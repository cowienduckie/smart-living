using System.Collections.Generic;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool IsExist(string id);

        IEnumerable<User> GetAll();

        User GetById(string id);
    }
}