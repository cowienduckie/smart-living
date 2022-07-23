using System.ComponentModel.DataAnnotations;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class DevicePostDto
    {
        [Required][Key] public int Id { get; set; }

        [Required][StringLength(200)] public string Name { get; set; }

        [Required] public int HouseId { get; set; }

        [Required] public int DeviceTypeId { get; set; }

        public int? AreaId { get; set; }

        public string Params { get; set; }

        [Required] public bool IsActive { get; set; } = false;
    }
}