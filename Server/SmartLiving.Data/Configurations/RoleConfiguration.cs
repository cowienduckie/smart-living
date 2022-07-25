using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
        }

        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(Role);
    }
}