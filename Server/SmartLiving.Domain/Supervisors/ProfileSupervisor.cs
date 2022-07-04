using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<ProfileGetDto> GetAllProfiles()
        {
            throw new NotImplementedException();
        }

        public ProfileGetDto GetProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public ProfileGetDto CreateProfile(ProfileGetDto newModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfile(ProfileGetDto updateModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProfile(int id)
        {
            throw new NotImplementedException();
        }
    }
}