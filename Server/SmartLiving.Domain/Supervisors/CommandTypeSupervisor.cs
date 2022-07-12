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
        public IEnumerable<CommandTypeGetDto> GetAllCommandTypes(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<CommandTypeGetDto>>(_commandTypeRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public CommandTypeGetDto GetCommandTypeById(int id, string userId)
        {
            var item = GetCache<CommandTypeGetDto>(id, userId);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<CommandTypeGetDto>(_commandTypeRepository.GetById(id, userId));
            
            if(item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public CommandTypeGetDto CreateCommandType(CommandTypeGetDto newModel, string userId)
        {
            var item = _mapper.Map<CommandType>(newModel);
            item = _commandTypeRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateCommandType(CommandTypeGetDto updateModel, string userId)
        {
            var item = _commandTypeRepository.GetById(updateModel.Id, userId);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _commandTypeRepository.Update(item, userId);
        }

        public bool DeleteCommandType(int id, string userId)
        {
            return _commandTypeRepository.Delete(id, userId);
        }
    }
}