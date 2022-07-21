using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaGetDto>();
            CreateMap<AreaGetDto, Area>();
            CreateMap<Area, AreaModel>().PreserveReferences();
            CreateMap<AreaModel, Area>().PreserveReferences();
        }
    }
}