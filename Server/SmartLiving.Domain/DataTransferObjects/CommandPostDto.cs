using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class CommandPostDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [Required]
        public int CommandTypeId { get; set; }
        [Required]
        public string Params { get; set; }
    }
}