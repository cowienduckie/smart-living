using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class AutoMessage : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

        [Required] public string Content { get; set; }

        [Required] public bool IsRead { get; set; }
    }
}
