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
        public IEnumerable<CommandGetDto> GetAllCommands()
        {
            var allItems = _mapper.Map<IEnumerable<CommandGetDto>>(_commandRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public CommandGetDto GetCommandById(int id)
        {
            var item = GetCache<CommandGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<CommandGetDto>(_commandRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public CommandGetDto CreateCommand(CommandGetDto newModel)
        {
            var item = _mapper.Map<Command>(newModel);
            item = _commandRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateCommand(CommandGetDto updateModel)
        {
            var item = _commandRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _commandRepository.Update(item);
        }

        public bool DeleteCommand(int id)
        {
            return _commandRepository.Delete(id);
        }
    }
}