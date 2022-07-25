using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class ScheduleConfiguration : ConfigurationBase<Schedule>
    {
        public override string TableName => nameof(Schedule);

        public override void ConfigureEntity(EntityTypeBuilder<Schedule> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(s => s.Commands)
                .WithOne(c => c.Schedule)
                .HasForeignKey(c => c.ScheduleId);

            entity.HasOne(s => s.User)
                .WithMany(u => u.Schedules)
                .HasForeignKey(s => s.UserId);

            entity.HasOne(s => s.Device)
                .WithMany(d => d.Schedules)
                .HasForeignKey(s => s.DeviceId);

            entity.HasOne(s => s.CommandType)
                .WithMany(ct => ct.Schedules)
                .HasForeignKey(s => s.CommandTypeId);
        }
    }
}