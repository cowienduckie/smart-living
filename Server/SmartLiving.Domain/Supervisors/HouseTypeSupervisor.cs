using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseTypeGetDto> GetAllHouseTypes()
        {
            var allItems = _mapper.Map<IEnumerable<HouseTypeGetDto>>(_houseTypeRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public HouseTypeGetDto GetHouseTypeById(int id)
        {
            var item = GetCache<HouseTypeGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<HouseTypeGetDto>(_houseTypeRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public HouseTypeGetDto CreateHouseType(HouseTypeGetDto newModel)
        {
            var item = _mapper.Map<HouseType>(newModel);
            item = _houseTypeRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateHouseType(HouseTypeGetDto updateModel)
        {
            var item = _houseTypeRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _houseTypeRepository.Update(item);
        }

        public bool DeleteHouseType(int id)
        {
            return _houseTypeRepository.Delete(id);
        }
    }
}