using System.Collections.Generic;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IHouseRepository : IBaseRepository<HouseModel>
    {
        IEnumerable<HouseModel> GetByUser(string userId);
    }
}