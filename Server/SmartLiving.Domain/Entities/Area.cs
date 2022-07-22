using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class Area : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        public virtual House House { get; set; }

        public virtual IList<Device> Devices { get; set; }
    }
}