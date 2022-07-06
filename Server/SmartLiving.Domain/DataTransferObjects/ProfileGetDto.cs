namespace SmartLiving.Domain.DataTransferObjects
{
    public class ProfileGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public bool IsAllowedOther { get; set; }
        public bool IsActive { get; set; }
    }
}