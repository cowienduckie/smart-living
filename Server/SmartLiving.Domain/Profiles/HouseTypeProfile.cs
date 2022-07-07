using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class HouseTypeProfile : Profile
    {
        public HouseTypeProfile()
        {
            CreateMap<HouseType, HouseTypeGetDto>();
            CreateMap<HouseTypeGetDto, HouseType>();
        }
    }
}