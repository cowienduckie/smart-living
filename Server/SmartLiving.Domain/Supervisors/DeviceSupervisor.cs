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
        public IEnumerable<DeviceGetDto> GetAllDevices(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<DeviceGetDto>>(_deviceRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public DeviceGetDto GetDeviceById(int id, string userId)
        {
            var item = GetCache<DeviceGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<DeviceGetDto>(_deviceRepository.GetById(id, userId));

            if(item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public DeviceGetDto CreateDevice(DeviceGetDto newModel, string userId)
        {
            var item = _mapper.Map<Device>(newModel);
            item = _deviceRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateDevice(DeviceGetDto updateModel, string userId)
        {
            var item = _deviceRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _deviceRepository.Update(item, userId);
        }

        public bool DeleteDevice(int id, string userId)
        {
            return _deviceRepository.Delete(id, userId);
        }
    }
}
