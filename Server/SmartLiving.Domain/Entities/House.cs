using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class House : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public string UserId { get; set; }

        public User User { get; set; }

        public virtual IList<Device> Devices { get; set; }
    }
}
