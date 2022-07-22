using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class HouseType : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public virtual IList<House> Houses { get; set; }
    }
}