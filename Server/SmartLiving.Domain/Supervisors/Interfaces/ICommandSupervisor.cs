using System.Collections.Generic;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<CommandGetDto> GetAllCommands();
        CommandGetDto GetCommandById(int id);
        CommandGetDto CreateCommand(CommandGetDto newModel);
        bool UpdateCommand(CommandGetDto updateModel);
        bool DeleteCommand(int id);
    }
}