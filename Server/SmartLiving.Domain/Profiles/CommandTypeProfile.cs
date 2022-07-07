using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class CommandTypeProfile : Profile
    {
        public CommandTypeProfile()
        {
            CreateMap<CommandType, CommandTypeGetDto>();
            CreateMap<CommandTypeGetDto, CommandType>();
        }
    }
}