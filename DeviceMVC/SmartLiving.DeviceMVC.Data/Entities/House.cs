using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLiving.DeviceMVC.Data.Entities
{
    public class House : BaseEntity
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public int HouseTypeId { get; set; }

        public virtual HouseType HouseType { get; set; }

        public virtual IList<Device> Devices { get; set; }

        public virtual IList<Area> Areas { get; set; }
    }
}