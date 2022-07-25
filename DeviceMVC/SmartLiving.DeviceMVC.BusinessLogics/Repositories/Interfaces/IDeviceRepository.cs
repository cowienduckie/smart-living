using Newtonsoft.Json.Linq;
using SmartLiving.DeviceMVC.Data.Entities;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        bool Switch(int id);
        Device CreateDevice(Device model);
        Device UpdateParams(int deviceId, JObject deviceParams);
    }
}