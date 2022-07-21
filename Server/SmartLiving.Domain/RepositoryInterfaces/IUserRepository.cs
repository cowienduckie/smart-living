using SmartLiving.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool IsExist(string id);
        IEnumerable<User> GetAll();
        User GetById(string id);
    }
}
