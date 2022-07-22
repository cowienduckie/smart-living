using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseTypeGetDto> GetAllHouseTypes(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<HouseTypeGetDto>>(_houseTypeRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public HouseTypeGetDto GetHouseTypeById(int id, string userId)
        {
            var item = GetCache<HouseTypeGetDto>(id, userId);
            if (item != null) return item;
            item = _mapper.Map<HouseTypeGetDto>(_houseTypeRepository.GetById(id, userId));

            if (item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public HouseTypeGetDto CreateHouseType(HouseTypeGetDto newModel, string userId)
        {
            var item = _mapper.Map<HouseType>(newModel);
            item = _houseTypeRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateHouseType(HouseTypeGetDto updateModel, string userId)
        {
            var item = _houseTypeRepository.GetById(updateModel.Id, userId);
            if (item == null) return false;
            _mapper.Map(updateModel, item);

            return _houseTypeRepository.Update(item, userId);
        }

        public bool DeleteHouseType(int id, string userId)
        {
            return _houseTypeRepository.Delete(id, userId);
        }
    }
}