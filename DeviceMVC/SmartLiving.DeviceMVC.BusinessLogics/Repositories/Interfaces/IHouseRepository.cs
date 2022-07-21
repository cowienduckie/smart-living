using SmartLiving.DeviceMVC.Data;
using SmartLiving.DeviceMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IHouseRepository : IBaseRepository<HouseModel>
    {
        IEnumerable<HouseModel> GetByUser(string userId);
    }
}
