using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLiving.DeviceMVC.Data.Entities
{
    public class HouseType : BaseEntity
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public virtual IList<House> Houses { get; set; }
    }
}