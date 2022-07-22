using SmartLiving.Library.DataTypes;
using System.Collections.Generic;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        PagedList<TEntity> GetPagedList<TEntity>(IList<TEntity> items, int pageIndex, int pageSize);
    }
}