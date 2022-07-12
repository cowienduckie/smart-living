using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseGetDto> GetAllHouses(string userId);
        HouseGetDto GetHouseById(int id, string userId);
        HouseGetDto CreateHouse(HouseGetDto newModel, string userId);
        bool UpdateHouse(HouseGetDto updateModel, string userId);
        bool DeleteHouse(int id, string userId);
    }
}