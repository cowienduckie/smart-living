using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<ScheduleGetDto> GetAllSchedules()
        {
            var allItems = _mapper.Map<IEnumerable<ScheduleGetDto>>(_scheduleRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public ScheduleGetDto GetScheduleById(int id)
        {
            var item = GetCache<ScheduleGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<ScheduleGetDto>(_scheduleRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public ScheduleGetDto CreateSchedule(ScheduleGetDto newModel)
        {
            var item = _mapper.Map<Schedule>(newModel);
            item = _scheduleRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateSchedule(ScheduleGetDto updateModel)
        {
            var item = _scheduleRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _scheduleRepository.Update(item);
        }

        public bool DeleteSchedule(int id)
        {
            return _scheduleRepository.Delete(id);
        }
    }
}