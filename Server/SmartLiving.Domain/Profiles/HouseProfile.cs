using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseGetDto>();
            CreateMap<HouseGetDto, House>();
        }
    }
}