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
            return _mapper.Map<IEnumerable<AreaModel>>(_areaRepository.GetAll()).ToList();
        }

        public IEnumerable<AreaGetDto> GetAllAreas(string userId)
        {
            //allItems.ForEach(item => SetCache(item.Id, item, userId));
            return _mapper.Map<IEnumerable<AreaGetDto>>(_areaRepository.GetAll(userId)).ToList();
        }

        public AreaModel GetAreaById(int id)
        {
            return _mapper.Map<AreaModel>(_areaRepository.GetById(id));
        }

        public AreaGetDto GetAreaById(int id, string userId)
        {
            //var item = GetCache<AreaGetDto>(id, userId);
            //if (item != null)
            //{
            //    return item;
            //}
            
            //if(item != null)
            //    SetCache(item.Id, item, userId);

            return _mapper.Map<AreaGetDto>(_areaRepository.GetById(id, userId));
        }

        public AreaPostDto CreateArea(AreaPostDto newModel, string userId)
        {
            var item = _mapper.Map<Area>(newModel);
            item = _areaRepository.Create(item, userId);
            newModel = _mapper.Map<AreaPostDto>(item);

            //if(newModel != null)
            //    SetCache(newModel.Id, newModel, userId);

            return newModel;
        }

        public bool UpdateArea(AreaPostDto updateModel, string userId)
        {
            var item = _areaRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            //if(updateModel != null)
            //    SetCache(updateModel.Id, updateModel, userId);

            return _areaRepository.Update(item, userId);
        }

        public bool DeleteArea(int id, string userId)
        {
            return _areaRepository.Delete(id, userId);
        }
    }
}