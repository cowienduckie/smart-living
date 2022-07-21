using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.DeviceMVC.Data.Entities;

namespace SmartLiving.DeviceMVC.BusinessLogic.DataContext.Configurations
{
    public class DeviceTypeConfiguration : ConfigurationBase<DeviceType>
    {
        public override string TableName => nameof(DeviceType);

        public override void ConfigureEntity(EntityTypeBuilder<DeviceType> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(dt => dt.Devices)
                .WithOne(d => d.DeviceType)
                .HasForeignKey(d => d.DeviceTypeId);
        }
    }
}