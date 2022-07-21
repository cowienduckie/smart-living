using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
