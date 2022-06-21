using System;
using System.Collections.Generic;

namespace SmartLiving.Domain.RepositoryInterfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        bool IsExist(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(int id);
    }
}