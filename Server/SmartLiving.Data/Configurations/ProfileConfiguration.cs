using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class ProfileConfiguration : ConfigurationBase<Profile>
    {
        public override string TableName => nameof(Profile);

        public override void ConfigureEntity(EntityTypeBuilder<Profile> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasMany(p => p.SharedWith)
                .WithOne(sw => sw.Profile)
                .HasForeignKey(sw => sw.ProfileId);

            entity.HasOne(p => p.User)
                .WithMany(u => u.Profiles)
                .HasForeignKey(p => p.UserId);

            entity.HasMany(p => p.ProfileDevices)
                .WithOne(pd => pd.Profile)
                .HasForeignKey(pd => pd.ProfileId);
        }
    }
}