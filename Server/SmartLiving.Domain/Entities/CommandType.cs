using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class CommandType : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Params { get; set; }

        public virtual IList<Command> Commands { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }
    }
}
