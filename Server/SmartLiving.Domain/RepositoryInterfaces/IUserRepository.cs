using SmartLiving.Domain.Entities;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool IsExist(string id);

        IEnumerable<User> GetAll();

        User GetById(string id);
    }
}