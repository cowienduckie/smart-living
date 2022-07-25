using AutoMapper;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Profiles
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<Entities.Profile, ProfileGetDto>();
            CreateMap<ProfileGetDto, Entities.Profile>();
        }
    }
}