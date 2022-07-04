using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class CommandConfiguration : ConfigurationBase<Command>
    {
        public override string TableName => nameof(Command);

        public override void ConfigureEntity(EntityTypeBuilder<Command> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasOne(c => c.User)
                .WithMany(u => u.Commands)
                .HasForeignKey(c => c.UserId);

            entity.HasOne(c => c.Schedule)
                .WithMany(s => s.Commands)
                .HasForeignKey(c => c.ScheduleId);

            entity.HasOne(c => c.CommandType)
                .WithMany(ct => ct.Commands)
                .HasForeignKey(c => c.CommandTypeId);

            entity.HasOne(c => c.Device)
                .WithMany(d => d.Commands)
                .HasForeignKey(c => c.DeviceId);
        }
    }
}