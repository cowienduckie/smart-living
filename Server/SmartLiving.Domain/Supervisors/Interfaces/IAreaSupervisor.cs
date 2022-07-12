using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<AreaGetDto> GetAllAreas(string userId);
        AreaGetDto GetAreaById(int id, string userId);
        AreaGetDto CreateArea(AreaGetDto newModel, string userId);
        bool UpdateArea(AreaGetDto updateModel, string userId);
        bool DeleteArea(int id, string userId);
    }
}