using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.DeviceMVC.Data.Entities;

namespace SmartLiving.DeviceMVC.BusinessLogics.DataContext.Configurations
{
    public class DeviceConfiguration : ConfigurationBase<Device>
    {
        public override string TableName => nameof(Device);

        public override void ConfigureEntity(EntityTypeBuilder<Device> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasOne(d => d.House)
                .WithMany(h => h.Devices)
                .HasForeignKey(d => d.HouseId);

            entity.HasOne(d => d.Area)
                .WithMany(a => a.Devices)
                .HasForeignKey(d => d.AreaId);

            entity.HasOne(d => d.DeviceType)
                .WithMany(dt => dt.Devices)
                .HasForeignKey(d => d.DeviceTypeId);
        }
    }
}