using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class ProfileDeviceConfiguration : ConfigurationBase<ProfileDevice>
    {
        public override string TableName => nameof(ProfileDevice);

        public override void ConfigureEntity(EntityTypeBuilder<ProfileDevice> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasOne(pd => pd.Device)
                .WithMany(d => d.ProfileDevices)
                .HasForeignKey(pd => pd.DeviceId);

            entity.HasOne(pd => pd.Profile)
                .WithMany(p => p.ProfileDevices)
                .HasForeignKey(pd => pd.ProfileId);
        }
    }
}