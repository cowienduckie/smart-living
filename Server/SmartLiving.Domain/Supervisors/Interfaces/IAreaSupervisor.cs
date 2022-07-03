using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<AreaGetDto> GetAllAreas();
        AreaGetDto GetAreaById(int id);
        AreaGetDto CreateArea(AreaGetDto newModel);
        bool UpdateArea(AreaGetDto updateModel);
        bool DeleteArea(int id);
    }
}