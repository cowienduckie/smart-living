using System.Collections.Generic;

namespace SmartLiving.DeviceMVC.Data.Models
{
    public class AreaModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HouseId { get; set; }

        public HouseModel House { get; set; }

        public List<DeviceModel> Devices { get; set; }
    }
}