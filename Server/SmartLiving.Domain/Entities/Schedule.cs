using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required] public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

        [Required] public int CommandTypeId { get; set; }

        public virtual CommandType CommandType { get; set; }

        [Required] public string Params { get; set; }

        public DateTime? TimeInterval { get; set; }

        [Required] public DateTime ActiveFrom { get; set; }

        public DateTime? ActiveLength { get; set; }

        [Required] public bool IsActive { get; set; }

        public virtual IList<Command> Commands { get; set; }
    }
}