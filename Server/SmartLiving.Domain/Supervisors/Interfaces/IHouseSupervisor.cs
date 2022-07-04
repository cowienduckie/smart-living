using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseGetDto> GetAllHouses();
        HouseGetDto GetHouseById(int id);
        HouseGetDto CreateHouse(HouseGetDto newModel);
        bool UpdateHouse(HouseGetDto updateModel);
        bool DeleteHouse(int id);
    }
}