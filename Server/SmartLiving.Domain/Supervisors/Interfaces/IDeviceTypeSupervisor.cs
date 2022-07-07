using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<DeviceTypeGetDto> GetAllDeviceTypes();
        DeviceTypeGetDto GetDeviceTypeById(int id);
        DeviceTypeGetDto CreateDeviceType(DeviceTypeGetDto newModel);
        bool UpdateDeviceType(DeviceTypeGetDto updateModel);
        bool DeleteDeviceType(int id);
    }
}
