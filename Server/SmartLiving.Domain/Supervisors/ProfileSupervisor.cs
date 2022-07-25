using System.Collections.Generic;
using System.Linq;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<ProfileGetDto> GetAllProfiles(string userId)
        {
            var allItems = _mapper.Map<IEnumerable<ProfileGetDto>>(_profileRepository.GetAll(userId)).ToList();
            allItems.ForEach(item => SetCache(item.Id, item, userId));

            return allItems;
        }

        public ProfileGetDto GetProfileById(int id, string userId)
        {
            var item = GetCache<ProfileGetDto>(id, userId);
            if (item != null) return item;
            item = _mapper.Map<ProfileGetDto>(_profileRepository.GetById(id, userId));

            if (item != null)
                SetCache(item.Id, item, userId);

            return item;
        }

        public ProfileGetDto CreateProfile(ProfileGetDto newModel, string userId)
        {
            var item = _mapper.Map<Profile>(newModel);
            item = _profileRepository.Create(item, userId);
            newModel.Id = item.Id;

            return newModel;
        }

        public bool UpdateProfile(ProfileGetDto updateModel, string userId)
        {
            var item = _profileRepository.GetById(updateModel.Id, userId);
            if (item == null) return false;
            _mapper.Map(updateModel, item);

            return _profileRepository.Update(item, userId);
        }

        public bool DeleteProfile(int id, string userId)
        {
            return _profileRepository.Delete(id, userId);
        }
    }
}