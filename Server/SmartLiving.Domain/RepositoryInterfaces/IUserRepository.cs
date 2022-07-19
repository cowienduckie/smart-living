using SmartLiving.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
