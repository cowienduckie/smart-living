using SmartLiving.DeviceMVC.Data;
using SmartLiving.DeviceMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(string id);
    }
}
