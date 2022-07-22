using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.Entities
{
    public class Command : BaseEntity
    {
        [Required][Key] public int Id { get; set; }

        public int? ScheduleId { get; set; }

        public virtual Schedule Schedule { get; set; }

        [Required] public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required] public int DeviceId { get; set; }

        public virtual Device Device { get; set; }

        [Required] public int CommandTypeId { get; set; }

        public virtual CommandType CommandType { get; set; }

        [Required] public string Params { get; set; }

        [Required] public bool IsExecuted { get; set; }
    }
}