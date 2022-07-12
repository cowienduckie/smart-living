using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseGetDto> GetAllHouses(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<HouseGetDto>>(_houseRepository.GetAll(userId)).ToList();


            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public HouseGetDto GetHouseById(int id, string userId)
        {
            var item = GetCache<HouseGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<HouseGetDto>(_houseRepository.GetById(id, userId));

            if(item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public HouseGetDto CreateHouse(HouseGetDto newModel, string userId)
        {
            var item = _mapper.Map<House>(newModel);
            item = _houseRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateHouse(HouseGetDto updateModel, string userId)
        {
            var item = _houseRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _houseRepository.Update(item, userId);
        }

        public bool DeleteHouse(int id, string userId)
        {
            return _houseRepository.Delete(id, userId);
        }
    }
}