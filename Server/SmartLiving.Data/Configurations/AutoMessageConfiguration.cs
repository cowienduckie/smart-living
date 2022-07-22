using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class AutoMessageConfiguration : ConfigurationBase<AutoMessage>
    {
        public override string TableName => nameof(AutoMessage);

        public override void ConfigureEntity(EntityTypeBuilder<AutoMessage> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasOne(am => am.Device)
                .WithMany(d => d.AutoMessages)
                .HasForeignKey(am => am.DeviceId);
        }
    }
}