using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class HouseTypeProfile : Profile
    {
        public HouseTypeProfile()
        {
            CreateMap<HouseType, HouseTypeGetDto>();
            CreateMap<HouseTypeGetDto, HouseType>();
            CreateMap<HouseType, HouseTypeModel>();
            CreateMap<HouseTypeModel, HouseType>();
        }
    }
}