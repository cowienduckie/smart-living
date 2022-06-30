using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<DeviceGetDto> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public DeviceGetDto GetDeviceById(int id)
        {
            throw new NotImplementedException();
        }

        public DeviceGetDto CreateDevice(DeviceGetDto newModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDevice(DeviceGetDto updateModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDevice(int id)
        {
            throw new NotImplementedException();
        }
    }
}
