using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
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

            entity.HasMany(d => d.ProfileDevices)
                .WithOne(pd => pd.Device)
                .HasForeignKey(pd => pd.DeviceId);

            entity.HasMany(d => d.Schedules)
                .WithOne(s => s.Device)
                .HasForeignKey(s => s.DeviceId);

            entity.HasMany(d => d.Commands)
                .WithOne(c => c.Device)
                .HasForeignKey(c => c.DeviceId);

            entity.HasMany(d => d.DeviceData)
                .WithOne(dd => dd.Device)
                .HasForeignKey(dd => dd.DeviceId);

            entity.HasMany(d => d.AutoMessages)
                .WithOne(am => am.Device)
                .HasForeignKey(am => am.DeviceId);

            entity.HasMany(d => d.DeviceCommandTypes)
                .WithOne(dct => dct.Device)
                .HasForeignKey(dct => dct.DeviceId);
        }
    }

    public class DeviceCommandTypeConfiguration
    {
        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(DeviceCommandType);

        public DeviceCommandTypeConfiguration(EntityTypeBuilder<DeviceCommandType> entity)
        {
            entity.HasKey(e => new {e.DeviceId, e.CommandTypeId});

            entity.HasOne(e => e.Device)
                .WithMany(d => d.DeviceCommandTypes)
                .HasForeignKey(e => e.DeviceId);

            entity.HasOne(e => e.CommandType)
                .WithMany(ct => ct.DeviceCommandTypes)
                .HasForeignKey(e => e.CommandTypeId);
        }
    }
}