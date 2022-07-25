using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Events;
using SmartLiving.Domain.Models;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<HouseModel> GetAllHouses()
        {
            return _mapper.Map<IEnumerable<HouseModel>>(_houseRepository.GetAll()).ToList();
        }

        public IEnumerable<HouseGetDto> GetAllHouses(string userId)
        {
            //allItems.ForEach(item => SetCache(item.Id, item, userId));
            return _mapper.Map<IEnumerable<HouseGetDto>>(_houseRepository.GetAll(userId)).ToList();
        }

        public HouseModel GetHouseById(int id)
        {
            return _mapper.Map<HouseModel>(_houseRepository.GetById(id));
        }

        public HouseGetDto GetHouseById(int id, string userId)
        {
            //var item = GetCache<HouseGetDto>(id, userId);
            //if (item != null)
            //{
            //    return item;
            //}

            //if(item != null)
            //    SetCache(item.Id, item, userId);

            return _mapper.Map<HouseGetDto>(_houseRepository.GetById(id, userId));
        }

        public HousePostDto CreateHouse(HousePostDto newModel, string userId)
        {
            var item = _mapper.Map<House>(newModel);
            item = _houseRepository.Create(item, userId);
            newModel = _mapper.Map<HousePostDto>(item);

            //Send Message
            var msgBody = JObject.FromObject(newModel);
            var msg = new ServerMsgEvent("CreateHouse", msgBody.ToString(Formatting.None));
            _messageService.SendMessage(msg);

            return newModel;
        }

        public bool UpdateHouse(HousePostDto updateModel, string userId)
        {
            var item = _houseRepository.GetById(updateModel.Id, userId);
            if (item == null) return false;
            _mapper.Map(updateModel, item);

            //if(updateModel != null)
            //    SetCache(updateModel.Id, updateModel, userId);

            return _houseRepository.Update(item, userId);
        }

        public bool DeleteHouse(int id, string userId)
        {
            return _houseRepository.Delete(id, userId);
        }
    }
}