using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<ProfileGetDto> GetAllProfiles();
        ProfileGetDto GetProfileById(int id);
        ProfileGetDto CreateProfile(ProfileGetDto newModel);
        bool UpdateProfile(ProfileGetDto updateModel);
        bool DeleteProfile(int id);
    }
}