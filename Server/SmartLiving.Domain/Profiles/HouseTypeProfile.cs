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
            CreateMap<HouseType, HouseTypeGetDto>().PreserveReferences();
            CreateMap<HouseTypeGetDto, HouseType>().PreserveReferences();
            CreateMap<HouseType, HouseTypeModel>().PreserveReferences();
            CreateMap<HouseTypeModel, HouseType>().PreserveReferences();
        }
    }
}