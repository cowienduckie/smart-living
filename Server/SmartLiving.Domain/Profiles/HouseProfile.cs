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
            CreateMap<House, HouseGetDto>().PreserveReferences();
            CreateMap<HouseGetDto, House>().PreserveReferences();
            CreateMap<House, HousePostDto>().PreserveReferences();
            CreateMap<HousePostDto, House>().PreserveReferences();
            CreateMap<House, HouseModel>().PreserveReferences();
            CreateMap<HouseModel, House>().PreserveReferences();
        }
    }
}