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
        public IEnumerable<DeviceTypeGetDto> GetAllDeviceTypes()
        {
            var allItems = _mapper.Map<IEnumerable<DeviceTypeGetDto>>(_deviceTypeRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public DeviceTypeGetDto GetDeviceTypeById(int id)
        {
            var item = GetCache<DeviceTypeGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<DeviceTypeGetDto>(_deviceTypeRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public DeviceTypeGetDto CreateDeviceType(DeviceTypeGetDto newModel)
        {
            var item = _mapper.Map<DeviceType>(newModel);
            item = _deviceTypeRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateDeviceType(DeviceTypeGetDto updateModel)
        {
            var item = _deviceTypeRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _deviceTypeRepository.Update(item);
        }

        public bool DeleteDeviceType(int id)
        {
            return _deviceTypeRepository.Delete(id);
        }
    }
}
