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
        public IEnumerable<ProfileGetDto> GetAllProfiles()
        {
            var allItems = _mapper.Map<IEnumerable<ProfileGetDto>>(_profileRepository.GetAll()).ToList();
            allItems.ForEach(item => SetCache(item.Id, item));

            return allItems;
        }

        public ProfileGetDto GetProfileById(int id)
        {
            var item = GetCache<ProfileGetDto>(id);
            if (item != null)
            {
                return item;
            }
            item = _mapper.Map<ProfileGetDto>(_profileRepository.GetById(id));
            SetCache(item.Id, item);

            return item;
        }

        public ProfileGetDto CreateProfile(ProfileGetDto newModel)
        {
            var item = _mapper.Map<Profile>(newModel);
            item = _profileRepository.Create(item);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateProfile(ProfileGetDto updateModel)
        {
            var item = _profileRepository.GetById(updateModel.Id);
            if (item == null)
            {
                return false;
            }
            _mapper.Map(updateModel, item);

            return _profileRepository.Update(item);
        }

        public bool DeleteProfile(int id)
        {
            return _profileRepository.Delete(id);
        }
    }
}