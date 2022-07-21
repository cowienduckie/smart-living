using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartLiving.DeviceMVC.Data.Entities
{
    public class DeviceType : BaseEntity
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string DefaultParams { get; set; }

        public virtual IList<Device> Devices { get; set; }
    }
}
