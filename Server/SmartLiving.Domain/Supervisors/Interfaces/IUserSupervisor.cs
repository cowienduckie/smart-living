using SmartLiving.Domain.Models;
using System.Collections.Generic;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel GetUserById(string id);
    }
}