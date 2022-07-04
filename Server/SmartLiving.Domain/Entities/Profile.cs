using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class Profile : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required] public bool IsAllowedOther { get; set; }

        [Required] public bool IsActive { get; set; }

        public virtual  IList<ProfileDevice> ProfileDevices { get; set; }

        public virtual  IList<SharedWith> SharedWith { get; set; }
    }
}
