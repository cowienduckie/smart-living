using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<AreaGetDto> GetAllAreas()
        {
            throw new NotImplementedException();
        }

        public AreaGetDto GetAreaById(int id)
        {
            throw new NotImplementedException();
        }

        public AreaGetDto CreateArea(AreaGetDto newModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateArea(AreaGetDto updateModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArea(int id)
        {
            throw new NotImplementedException();
        }
    }
}