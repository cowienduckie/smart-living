using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class ProfileDevice : BaseEntity
    {
        [Required] [Key] public int Id { get; set; }

        [Required] public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        [Required] public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}