using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class CommandType : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string DefaultParams { get; set; }

        public virtual IList<Command> Commands { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }

        public virtual IList<DeviceCommandType> DeviceCommandTypes { get; set; }

        public virtual IList<DeviceTypeCommandType> DeviceTypeCommandTypes { get; set; }
    }
}