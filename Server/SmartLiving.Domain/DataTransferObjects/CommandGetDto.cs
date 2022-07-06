namespace SmartLiving.Domain.DataTransferObjects
{
    public class CommandGetDto
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string UserId { get; set; }
        public int DeviceId { get; set; }
        public int CommandTypeId { get; set; }
        public string Params { get; set; }
        public bool IsExecuted { get; set; }
    }
}