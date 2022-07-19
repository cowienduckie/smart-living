using System.Collections.Generic;

namespace SmartLiving.DeviceMVC.Entities.Models
{
    public class HouseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public UserModel User { get; set; }

        public int HouseTypeId { get; set; }

        public HouseTypeModel HouseType { get; set; }

        public List<DeviceModel> Devices { get; set; }

        public List<AreaModel> Areas { get; set; }
    }
}