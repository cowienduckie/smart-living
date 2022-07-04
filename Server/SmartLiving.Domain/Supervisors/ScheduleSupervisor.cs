using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<ScheduleGetDto> GetAllSchedules()
        {
            throw new NotImplementedException();
        }

        public ScheduleGetDto GetScheduleById(int id)
        {
            throw new NotImplementedException();
        }

        public ScheduleGetDto CreateSchedule(ScheduleGetDto newModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSchedule(ScheduleGetDto updateModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSchedule(int id)
        {
            throw new NotImplementedException();
        }
    }
}