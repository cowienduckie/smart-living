using System;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class ScheduleGetDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DeviceId { get; set; }
        public int CommandTypeId { get; set; }
        public string Params { get; set; }
        public DateTime? TimeInterval { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveLength { get; set; }
        public bool IsActive { get; set; }
    }
}