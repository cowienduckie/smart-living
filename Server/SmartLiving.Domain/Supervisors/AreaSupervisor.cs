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
        public IEnumerable<AreaGetDto> GetAllAreas()
        {
            var allItems = _mapper.Map<IEnumerable<AreaGetDto>>(_areaRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public AreaGetDto GetAreaById(int id)
        {
            var item = GetCache<AreaGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<AreaGetDto>(_areaRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public AreaGetDto CreateArea(AreaGetDto newModel)
        {
            var item = _mapper.Map<Area>(newModel);
            item = _areaRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateArea(AreaGetDto updateModel)
        {
            var item = _areaRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _areaRepository.Update(item);
        }

        public bool DeleteArea(int id)
        {
            return _areaRepository.Delete(id);
        }
    }
}