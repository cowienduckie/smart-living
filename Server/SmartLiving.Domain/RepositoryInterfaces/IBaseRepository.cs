using System;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        bool IsExist(int id);

        IEnumerable<TEntity> GetAll(string userId);

        TEntity GetById(int id, string userId);

        TEntity Create(TEntity entity, string userId);

        bool Update(TEntity entity, string userId);

        bool Delete(int id, string userId);
    }
}