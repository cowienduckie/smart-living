using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<CommandTypeGetDto> GetAllCommandTypes();
        CommandTypeGetDto GetCommandTypeById(int id);
        CommandTypeGetDto CreateCommandType(CommandTypeGetDto newModel);
        bool UpdateCommandType(CommandTypeGetDto updateModel);
        bool DeleteCommandType(int id);
    }
}