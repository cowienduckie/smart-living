using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<DeviceTypeGetDto> GetAllDeviceTypes(string userId);

        DeviceTypeGetDto GetDeviceTypeById(int id, string userId);

        DeviceTypeGetDto CreateDeviceType(DeviceTypeGetDto newMode, string userId);

        bool UpdateDeviceType(DeviceTypeGetDto updateModel, string userId);

        bool DeleteDeviceType(int id, string userId);
    }
}