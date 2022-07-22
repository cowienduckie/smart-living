using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class DeviceTypeConfiguration : ConfigurationBase<DeviceType>
    {
        public override string TableName => nameof(DeviceType);

        public override void ConfigureEntity(EntityTypeBuilder<DeviceType> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasMany(dt => dt.Devices)
                .WithOne(d => d.DeviceType)
                .HasForeignKey(d => d.DeviceTypeId);

            entity.HasMany(dt => dt.DeviceTypeCommandTypes)
                .WithOne(dtct => dtct.DeviceType)
                .HasForeignKey(dtct => dtct.DeviceTypeId);
        }
    }

    public class DeviceTypeCommandTypeConfiguration
    {
        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(DeviceTypeCommandType);

        public DeviceTypeCommandTypeConfiguration(EntityTypeBuilder<DeviceTypeCommandType> entity)
        {
            entity.HasKey(e => new { e.DeviceTypeId, e.CommandTypeId });

            entity.HasOne(e => e.DeviceType)
                .WithMany(dt => dt.DeviceTypeCommandTypes)
                .HasForeignKey(e => e.DeviceTypeId);

            entity.HasOne(e => e.CommandType)
                .WithMany(ct => ct.DeviceTypeCommandTypes)
                .HasForeignKey(e => e.CommandTypeId);
        }
    }
}