using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseTypeGetDto> GetAllHouseTypes(string userId);

        HouseTypeGetDto GetHouseTypeById(int id, string userId);

        HouseTypeGetDto CreateHouseType(HouseTypeGetDto newModel, string userId);

        bool UpdateHouseType(HouseTypeGetDto updateModel, string userId);

        bool DeleteHouseType(int id, string userId);
    }
}