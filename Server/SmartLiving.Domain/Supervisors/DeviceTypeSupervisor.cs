using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<DeviceTypeGetDto> GetAllDeviceTypes(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<DeviceTypeGetDto>>(_deviceTypeRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public DeviceTypeGetDto GetDeviceTypeById(int id, string userId)
        {
            var item = GetCache<DeviceTypeGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<DeviceTypeGetDto>(_deviceTypeRepository.GetById(id, userId));

            if (item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public DeviceTypeGetDto CreateDeviceType(DeviceTypeGetDto newModel, string userId)
        {
            var item = _mapper.Map<DeviceType>(newModel);
            item = _deviceTypeRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateDeviceType(DeviceTypeGetDto updateModel, string userId)
        {
            var item = _deviceTypeRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _deviceTypeRepository.Update(item, userId);
        }

        public bool DeleteDeviceType(int id, string userId)
        {
            return _deviceTypeRepository.Delete(id, userId);
        }
    }
}