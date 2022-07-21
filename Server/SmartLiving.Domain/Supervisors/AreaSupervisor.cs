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
        public IEnumerable<AreaModel> GetAllAreas()
        {
            var allItems = _mapper.Map<IEnumerable<AreaModel>>(_areaRepository.GetAll()).ToList();

            return allItems;
        }

        public IEnumerable<AreaGetDto> GetAllAreas(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<AreaGetDto>>(_areaRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public AreaModel GetAreaById(int id)
        {
            var item = _mapper.Map<AreaModel>(_areaRepository.GetById(id));

            return item;
        }

        public AreaGetDto GetAreaById(int id, string userId)
        {
            var item = GetCache<AreaGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<AreaGetDto>(_areaRepository.GetById(id, userId));

            if(item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public IEnumerable<AreaGetDto> GetAreaByHouse(int houseId, string userId)
        {
            var allItems = _mapper.Map<IEnumerable<AreaGetDto>>(_areaRepository.GetByHouse(houseId, userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public AreaGetDto CreateArea(AreaGetDto newModel, string userId)
        {
            var item = _mapper.Map<Area>(newModel);
            item = _areaRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateArea(AreaGetDto updateModel, string userId)
        {
            var item = _areaRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _areaRepository.Update(item, userId);
        }

        public bool DeleteArea(int id, string userId)
        {
            return _areaRepository.Delete(id, userId);
        }
    }
}