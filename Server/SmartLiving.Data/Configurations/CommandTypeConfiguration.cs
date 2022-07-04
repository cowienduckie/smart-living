using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class CommandTypeConfiguration : ConfigurationBase<CommandType>
    {
        public override string TableName => nameof(CommandType);

        public override void ConfigureEntity(EntityTypeBuilder<CommandType> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(ct => ct.Schedules)
                .WithOne(s => s.CommandType)
                .HasForeignKey(s => s.CommandTypeId);

            entity.HasMany(ct => ct.Commands)
                .WithOne(c => c.CommandType)
                .HasForeignKey(c => c.CommandTypeId);
        }
    }
}