using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseModel> GetAllHouses();
        HouseModel GetHouseById(int id);
        IEnumerable<HouseGetDto> GetAllHouses(string userId);
        HouseGetDto GetHouseById(int id, string userId);
        HouseGetDto CreateHouse(HouseGetDto newModel, string userId);
        bool UpdateHouse(HouseGetDto updateModel, string userId);
        bool DeleteHouse(int id, string userId);
    }
}