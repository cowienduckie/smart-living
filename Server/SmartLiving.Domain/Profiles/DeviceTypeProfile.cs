using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class DeviceTypeProfile : Profile
    {
        public DeviceTypeProfile()
        {
            CreateMap<DeviceType, DeviceTypeGetDto>();
            CreateMap<DeviceTypeGetDto, DeviceType>();
        }
    }
}