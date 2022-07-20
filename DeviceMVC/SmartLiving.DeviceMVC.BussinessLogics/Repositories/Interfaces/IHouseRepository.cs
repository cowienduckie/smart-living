using SmartLiving.DeviceMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BussinessLogics.Repositories.Interfaces
{
    public interface IHouseRepository : IBaseRepository<HouseModel>
    {
        IEnumerable<HouseModel> GetByUser(string userId);
    }
}
