using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Events;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<CommandGetDto> GetAllCommands(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<CommandGetDto>>(_commandRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public CommandGetDto GetCommandById(int id, string userId)
        {
            var item = GetCache<CommandGetDto>(id, userId);
            if (item != null) return item;
            item = _mapper.Map<CommandGetDto>(_commandRepository.GetById(id, userId));

            if (item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public CommandGetDto CreateCommand(CommandGetDto newModel, string userId)
        {
            var item = _mapper.Map<Command>(newModel);
            item = _commandRepository.Create(item, userId);
            newModel.Id = item.Id;

            //Send Message
            var msgBody = JObject.Parse(_deviceRepository.GetById(newModel.DeviceId).Params);
            var msg = new
            {
                Title = "PostCommand",
                Msg = msgBody.ToString(Formatting.None),
                DeviceId = $"{newModel.DeviceId}"
            };
            _messageService.SendMessage(msg);

            return newModel;
        }

        public bool UpdateCommand(CommandGetDto updateModel, string userId)
        {
            var item = _commandRepository.GetById(updateModel.Id, userId);
            if (item == null) return false;
            _mapper.Map(updateModel, item);

            return _commandRepository.Update(item, userId);
        }

        public bool DeleteCommand(int id, string userId)
        {
            return _commandRepository.Delete(id, userId);
        }

        public bool Switch(int deviceId, string userId)
        {
            var result = _commandRepository.Switch(deviceId, userId);

            if (result)
            {
                _messageService.SendMessage(new ServerMsgEvent("Switch", $"{deviceId}"));
            }

            return result;
        }
    }
}