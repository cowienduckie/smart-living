using System.Collections.Generic;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(string id);
    }
}