using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<UserModel> GetAllUsers()
        {
            var allItems = _mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll()).ToList();

            return allItems;
        }

        public UserModel GetUserById(string id)
        {
            var item = _mapper.Map<UserModel>(_userRepository.GetById(id));

            return item;
        }
    }
}