using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<ScheduleGetDto> GetAllSchedules(string userId);
        ScheduleGetDto GetScheduleById(int id, string userId);
        ScheduleGetDto CreateSchedule(ScheduleGetDto newModel, string userId);
        bool UpdateSchedule(ScheduleGetDto updateModel, string userId);
        bool DeleteSchedule(int id, string userId);
    }
}