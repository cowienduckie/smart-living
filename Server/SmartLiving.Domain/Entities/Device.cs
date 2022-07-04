using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class Device : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        public virtual House House { get; set; }

        [Required] public int DeviceTypeId { get; set; }

        public virtual  DeviceType DeviceType { get; set; }

        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }

        [Required] public string Params { get; set; }

        [Required] public string Status { get; set; } = "Off";

        public DateTime? TimeActivated { get; set; }

        public DateTime? TimeDeactivated { get; set; }

        [Required] public bool IsActive { get; set; }

        public virtual IList<ProfileDevice> ProfileDevices { get; set; }

        public virtual IList<Command> Commands { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }

        public virtual IList<DeviceData> DeviceData { get; set; }

        public virtual IList<AutoMessage> AutoMessages { get; set; }
    }
}