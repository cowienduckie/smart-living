using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<ScheduleGetDto> GetAllSchedules();
        ScheduleGetDto GetScheduleById(int id);
        ScheduleGetDto CreateSchedule(ScheduleGetDto newModel);
        bool UpdateSchedule(ScheduleGetDto updateModel);
        bool DeleteSchedule(int id);
    }
}