using SmartLiving.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<CommandGetDto> GetAllCommands(string userId);

        CommandGetDto GetCommandById(int id, string userId);

        CommandGetDto CreateCommand(CommandGetDto newModel, string userId);

        bool UpdateCommand(CommandGetDto updateModel, string userId);

        bool DeleteCommand(int id, string userId);
    }
}