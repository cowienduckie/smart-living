using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<DeviceGetDto> GetAllDevices();
        DeviceGetDto GetDeviceById(int id);
        DeviceGetDto CreateDevice(DeviceGetDto newModel);
        bool UpdateDevice(DeviceGetDto updateModel);
        bool DeleteDevice(int id);
    }
}
