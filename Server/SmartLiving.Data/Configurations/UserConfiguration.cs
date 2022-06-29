using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class UserConfiguration
    {
        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(User);

        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(u => u.Houses)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);

            entity.HasMany(u => u.Profiles)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            entity.HasMany(u => u.SharedWith)
                .WithOne(sw => sw.User)
                .HasForeignKey(sw => sw.UserId);

            entity.HasMany(u => u.Commands)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            entity.HasMany(u => u.Schedules)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}