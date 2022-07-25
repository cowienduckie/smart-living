namespace SmartLiving.DeviceMVC.Data.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HouseId { get; set; }

        public HouseModel House { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceTypeModel DeviceType { get; set; }

        public int? AreaId { get; set; }

        public AreaModel Area { get; set; }

        public string Params { get; set; }

        public bool IsActive { get; set; }
    }
}