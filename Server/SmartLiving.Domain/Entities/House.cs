using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class House : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required] public int HouseTypeId { get; set; }

        public virtual HouseType HouseType { get; set; }

        public virtual IList<Device> Devices { get; set; }

        public virtual IList<Area> Areas { get; set; }
    }
}