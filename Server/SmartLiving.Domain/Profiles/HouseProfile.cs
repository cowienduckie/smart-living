using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseGetDto>();
            CreateMap<HouseGetDto, House>();
            CreateMap<House, HouseModel>().PreserveReferences();
            CreateMap<HouseModel, House>().PreserveReferences();
        }
    }
}