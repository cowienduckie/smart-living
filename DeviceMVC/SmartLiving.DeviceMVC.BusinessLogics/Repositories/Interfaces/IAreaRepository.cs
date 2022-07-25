using SmartLiving.DeviceMVC.Data.Entities;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Area CreateArea(Area toObject);
    }
}