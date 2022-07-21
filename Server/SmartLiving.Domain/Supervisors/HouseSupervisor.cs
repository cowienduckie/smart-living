using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseModel> GetAllHouses()
        {
            var allItems = _mapper.Map<IEnumerable<HouseModel>>(_houseRepository.GetAll()).ToList();

            return allItems;
        }

        public IEnumerable<HouseGetDto> GetAllHouses(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<HouseGetDto>>(_houseRepository.GetAll(userId)).ToList();


            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public HouseModel GetHouseById(int id)
        {
            var item = _mapper.Map<HouseModel>(_houseRepository.GetById(id));

            return item;
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

        public HousePostDto CreateHouse(HousePostDto newModel, string userId)
        {
            var item = _mapper.Map<House>(newModel);
            item = _houseRepository.Create(item, userId);
            newModel = _mapper.Map<HousePostDto>(item);

            if(newModel != null)
                SetCache(newModel.Id, newModel, userId);

            return newModel;
        }

        public bool UpdateHouse(HousePostDto updateModel, string userId)
        {
            var item = _houseRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            if(updateModel != null)
                SetCache(updateModel.Id, updateModel, userId);

            return _houseRepository.Update(item, userId);
        }

        public bool DeleteHouse(int id, string userId)
        {
            return _houseRepository.Delete(id, userId);
        }
    }
}