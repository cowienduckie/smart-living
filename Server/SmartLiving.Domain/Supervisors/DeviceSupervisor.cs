using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<DeviceModel> GetAllDevices()
        {
            var allItems = _mapper.Map<IEnumerable<DeviceModel>>(_deviceRepository.GetAll()).ToList();

            return allItems;
        }

        public IEnumerable<DeviceGetDto> GetAllDevices(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<DeviceGetDto>>(_deviceRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public DeviceModel GetDeviceById(int id)
        {
            var item = _mapper.Map<DeviceModel>(_deviceRepository.GetById(id));

            return item;
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

        public DevicePostDto CreateDevice(DevicePostDto newModel, string userId)
        {
            var item = _mapper.Map<Device>(newModel);
            item = _deviceRepository.Create(item, userId);
            newModel = _mapper.Map<DevicePostDto>(item);

            if (newModel != null)
            {
                SetCache(newModel.Id, newModel, userId);
            }

            return newModel;
        }

        public bool UpdateDevice(DevicePostDto updateModel, string userId)
        {
            var item = _deviceRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            if (updateModel != null)
            {
                SetCache(updateModel.Id, updateModel, userId);
            }

            return _deviceRepository.Update(item, userId);
        }

        public bool DeleteDevice(int id, string userId)
        {
            return _deviceRepository.Delete(id, userId);
        }
    }
}
