using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class DeviceDataConfiguration : ConfigurationBase<DeviceData>
    {
        public override string TableName => nameof(DeviceData);

        public override void ConfigureEntity(EntityTypeBuilder<DeviceData> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasOne(dd => dd.Device)
                .WithMany(d => d.DeviceData)
                .HasForeignKey(dd => dd.DeviceId);
        }
    }
}