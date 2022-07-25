using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartLiving.DeviceMVC.Data.Entities
{
    public class Device : BaseEntity
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        public virtual House House { get; set; }

        [Required] public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }

        [Required] public string Params { get; set; }

        [Required] public bool IsActive { get; set; }
    }
}