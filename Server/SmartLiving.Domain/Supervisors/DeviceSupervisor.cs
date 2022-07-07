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
        public IEnumerable<DeviceGetDto> GetAllDevices()
        {
            var allItems = _mapper.Map<IEnumerable<DeviceGetDto>>(_deviceRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public DeviceGetDto GetDeviceById(int id)
        {
            var item = GetCache<DeviceGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<DeviceGetDto>(_deviceRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public DeviceGetDto CreateDevice(DeviceGetDto newModel)
        {
            var item = _mapper.Map<Device>(newModel);
            item = _deviceRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateDevice(DeviceGetDto updateModel)
        {
            var item = _deviceRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _deviceRepository.Update(item);
        }

        public bool DeleteDevice(int id)
        {
            return _deviceRepository.Delete(id);
        }
    }
}
