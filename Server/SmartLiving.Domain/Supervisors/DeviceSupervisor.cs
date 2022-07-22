using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<DeviceModel> GetAllDevices()
        {
            return _mapper.Map<IEnumerable<DeviceModel>>(_deviceRepository.GetAll()).ToList();
        }

        public IEnumerable<DeviceGetDto> GetAllDevices(string userId)
        {
            //allItems.ForEach(item => SetCache(item.Id, item, userId));
            return _mapper.Map<IEnumerable<DeviceGetDto>>(_deviceRepository.GetAll(userId)).ToList();
        }

        public DeviceModel GetDeviceById(int id)
        {
            return _mapper.Map<DeviceModel>(_deviceRepository.GetById(id));
        }

        public DeviceGetDto GetDeviceById(int id, string userId)
        {
            //var item = GetCache<DeviceGetDto>(id, userId);
            //if (item != null)
            //{
            //    return item;
            //}

            //if(item != null)
            //    SetCache(item.Id, item, userId);

            return _mapper.Map<DeviceGetDto>(_deviceRepository.GetById(id, userId));
        }

        public DevicePostDto CreateDevice(DevicePostDto newModel, string userId)
        {
            var item = _mapper.Map<Device>(newModel);
            item = _deviceRepository.Create(item, userId);
            newModel = _mapper.Map<DevicePostDto>(item);

            //if (newModel != null)
            //{
            //    SetCache(newModel.Id, newModel, userId);
            //}

            return newModel;
        }

        public bool UpdateDevice(DevicePostDto updateModel, string userId)
        {
            var item = _deviceRepository.GetById(updateModel.Id, userId);
            if (item == null) return false;
            _mapper.Map(updateModel, item);

            //if (updateModel != null)
            //{
            //    SetCache(updateModel.Id, updateModel, userId);
            //}

            return _deviceRepository.Update(item, userId);
        }

        public bool DeleteDevice(int id, string userId)
        {
            return _deviceRepository.Delete(id, userId);
        }
    }
}