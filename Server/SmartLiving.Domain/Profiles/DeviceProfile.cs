using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceGetDto>();
            CreateMap<DeviceGetDto, Device>();
        }
    }
}