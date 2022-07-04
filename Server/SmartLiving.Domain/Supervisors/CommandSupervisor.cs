using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors
{
    public partial class Supervisor
    {
        public IEnumerable<CommandGetDto> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public CommandGetDto GetCommandById(int id)
        {
            throw new NotImplementedException();
        }

        public CommandGetDto CreateCommand(CommandGetDto newModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCommand(CommandGetDto updateModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCommand(int id)
        {
            throw new NotImplementedException();
        }
    }
}