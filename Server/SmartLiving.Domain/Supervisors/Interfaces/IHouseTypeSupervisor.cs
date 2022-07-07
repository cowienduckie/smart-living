using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<HouseTypeGetDto> GetAllHouseTypes();
        HouseTypeGetDto GetHouseTypeById(int id);
        HouseTypeGetDto CreateHouseType(HouseTypeGetDto newModel);
        bool UpdateHouseType(HouseTypeGetDto updateModel);
        bool DeleteHouseType(int id);
    }
}