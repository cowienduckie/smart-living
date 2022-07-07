using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandGetDto>();
            CreateMap<CommandGetDto, Command>();
        }
    }
}