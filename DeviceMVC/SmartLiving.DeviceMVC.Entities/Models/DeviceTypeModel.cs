namespace SmartLiving.DeviceMVC.Entities.Models
{
    public class DeviceTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<DeviceTypeCommandTypeModel> DeviceTypeCommandTypes { get; set; }
    }

    public class DeviceTypeCommandTypeModel
    {
        public int DeviceTypeId { get; set; }
        public virtual DeviceTypeModel DeviceType { get; set; }
        public int CommandTypeId { get; set; }
        public virtual CommandTypeModel CommandType { get; set;}
    }
}