using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<DeviceModel> GetAllDevices();

        DeviceModel GetDeviceById(int id);

        IEnumerable<DeviceGetDto> GetAllDevices(string userId);

        DeviceGetDto GetDeviceById(int id, string userId);

        DevicePostDto CreateDevice(DevicePostDto newModel, string userId);

        bool UpdateDevice(DevicePostDto updateModel, string userId);

        bool DeleteDevice(int id, string userId);
    }
}