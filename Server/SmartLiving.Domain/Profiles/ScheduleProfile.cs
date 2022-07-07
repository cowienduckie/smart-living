using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace SmartLiving.Domain.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleGetDto>();
            CreateMap<ScheduleGetDto, Schedule>();
        }
    }
}