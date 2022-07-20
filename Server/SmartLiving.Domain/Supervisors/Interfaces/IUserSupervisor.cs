using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(string id);
    }
}