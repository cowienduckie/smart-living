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
        public IEnumerable<CommandTypeGetDto> GetAllCommandTypes()
        {
            var allItems = _mapper.Map<IEnumerable<CommandTypeGetDto>>(_commandTypeRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public CommandTypeGetDto GetCommandTypeById(int id)
        {
            var item = GetCache<CommandTypeGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<CommandTypeGetDto>(_commandTypeRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public CommandTypeGetDto CreateCommandType(CommandTypeGetDto newModel)
        {
            var item = _mapper.Map<CommandType>(newModel);
            item = _commandTypeRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateCommandType(CommandTypeGetDto updateModel)
        {
            var item = _commandTypeRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _commandTypeRepository.Update(item);
        }

        public bool DeleteCommandType(int id)
        {
            return _commandTypeRepository.Delete(id);
        }
    }
}