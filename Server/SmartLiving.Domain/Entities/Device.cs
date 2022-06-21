using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class Device : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        public House House { get; set; }
    }
}