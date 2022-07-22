using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Models;
using System.Collections.Generic;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseModel> GetAllHouses();

        HouseModel GetHouseById(int id);

        IEnumerable<HouseGetDto> GetAllHouses(string userId);

        HouseGetDto GetHouseById(int id, string userId);

        HousePostDto CreateHouse(HousePostDto newModel, string userId);

        bool UpdateHouse(HousePostDto updateModel, string userId);

        bool DeleteHouse(int id, string userId);
    }
}