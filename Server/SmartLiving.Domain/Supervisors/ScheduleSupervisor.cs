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
        public IEnumerable<ScheduleGetDto> GetAllSchedules(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<ScheduleGetDto>>(_scheduleRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public ScheduleGetDto GetScheduleById(int id, string userId)
        {
            var item = GetCache<ScheduleGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<ScheduleGetDto>(_scheduleRepository.GetById(id, userId));
            
            if(item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public ScheduleGetDto CreateSchedule(ScheduleGetDto newModel, string userId)
        {
            var item = _mapper.Map<Schedule>(newModel);
            item = _scheduleRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateSchedule(ScheduleGetDto updateModel, string userId)
        {
            var item = _scheduleRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _scheduleRepository.Update(item, userId);
        }

        public bool DeleteSchedule(int id, string userId)
        {
            return _scheduleRepository.Delete(id, userId);
        }
    }
}