using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class DeviceType : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string DefaultParams { get; set; }

        public virtual IList<Device> Devices { get; set; }

        public virtual IList<DeviceTypeCommandType> DeviceTypeCommandTypes { get; set; }
    }

    public class DeviceTypeCommandType
    {
        public int DeviceTypeId { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public int CommandTypeId { get; set; }
        public virtual CommandType CommandType { get; set;}
    }
}
