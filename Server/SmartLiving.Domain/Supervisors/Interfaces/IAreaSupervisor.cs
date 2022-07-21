using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<AreaModel> GetAllAreas();
        IEnumerable<AreaGetDto> GetAllAreas(string userId);
        AreaModel GetAreaById(int id);
        AreaGetDto GetAreaById(int id, string userId);
        IEnumerable<AreaGetDto> GetAreaByHouse(int houseId, string userId);
        AreaPostDto CreateArea(AreaPostDto newModel, string userId);
        bool UpdateArea(AreaPostDto updateModel, string userId);
        bool DeleteArea(int id, string userId);
    }
}