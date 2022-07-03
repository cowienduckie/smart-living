using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartLiving.Domain.Entities
{
    public class SharedWith : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        [Required] public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
