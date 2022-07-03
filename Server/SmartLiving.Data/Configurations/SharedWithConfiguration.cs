using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class SharedWithConfiguration : ConfigurationBase<SharedWith>
    {
        public override string TableName => nameof(SharedWith);

        public override void ConfigureEntity(EntityTypeBuilder<SharedWith> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasOne(sw => sw.Profile)
                .WithMany(p => p.SharedWith)
                .HasForeignKey(sw => sw.ProfileId);

            entity.HasOne(sw => sw.User)
                .WithMany(u => u.SharedWith)
                .HasForeignKey(sw => sw.UserId);
        }
    }
}