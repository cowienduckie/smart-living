using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class DeviceData : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public int DeviceId { get; set; }

        public Device Device { get; set; }

        public string Description { get; set; }

        [Required] public string Location { get; set; }
    }
}
