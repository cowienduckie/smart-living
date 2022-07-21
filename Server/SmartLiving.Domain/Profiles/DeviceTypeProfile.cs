using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class DeviceTypeProfile : Profile
    {
        public DeviceTypeProfile()
        {
            CreateMap<DeviceType, DeviceTypeGetDto>().PreserveReferences();
            CreateMap<DeviceTypeGetDto, DeviceType>().PreserveReferences();
            CreateMap<DeviceType, DeviceTypeModel>().PreserveReferences();
            CreateMap<DeviceTypeModel, DeviceType>().PreserveReferences();
        }
    }
}