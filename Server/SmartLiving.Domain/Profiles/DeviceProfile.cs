using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceGetDto>().PreserveReferences();
            CreateMap<DeviceGetDto, Device>().PreserveReferences();
            CreateMap<Device, DevicePostDto>().PreserveReferences();
            CreateMap<DevicePostDto, Device>().PreserveReferences();
            CreateMap<Device, DeviceModel>().PreserveReferences();
            CreateMap<DeviceModel, Device>().PreserveReferences();
        }
    }
}