using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<CommandTypeGetDto> GetAllCommandTypes(string userId);

        CommandTypeGetDto GetCommandTypeById(int id, string userId);

        CommandTypeGetDto CreateCommandType(CommandTypeGetDto newModel, string userId);

        bool UpdateCommandType(CommandTypeGetDto updateModel, string userId);

        bool DeleteCommandType(int id, string userId);
    }
}