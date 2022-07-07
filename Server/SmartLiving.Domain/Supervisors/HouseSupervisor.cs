using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseGetDto> GetAllHouses()
        {
            var allItems = _mapper.Map<IEnumerable<HouseGetDto>>(_houseRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public HouseGetDto GetHouseById(int id)
        {
            var item = GetCache<HouseGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<HouseGetDto>(_houseRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public HouseGetDto CreateHouse(HouseGetDto newModel)
        {
            var item = _mapper.Map<House>(newModel);
            item = _houseRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateHouse(HouseGetDto updateModel)
        {
            var item = _houseRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _houseRepository.Update(item);
        }

        public bool DeleteHouse(int id)
        {
            return _houseRepository.Delete(id);
        }
    }
}