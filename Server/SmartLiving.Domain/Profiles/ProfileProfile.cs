using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, ProfileGetDto>();
            CreateMap<ProfileGetDto, Profile>();
        }
    }
}