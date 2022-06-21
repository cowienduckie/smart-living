using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(u => u.Houses)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId);
        }

        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(User);
    }
}