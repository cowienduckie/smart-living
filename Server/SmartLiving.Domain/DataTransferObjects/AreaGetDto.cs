using System.Collections.Generic;

namespace SmartLiving.Domain.DataTransferObjects
{
    public class AreaGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseId { get; set; }
        public List<DeviceGetDto> Devices { get; set; }
        public HouseGetDto House { get; set; }
    }
}