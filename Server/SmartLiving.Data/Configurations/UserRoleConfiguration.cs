using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class UserRoleConfiguration
    {
        public string SchemaName { get; } = "dbo";

        public string TableName => nameof(UserRole);

        public UserRoleConfiguration(EntityTypeBuilder<UserRole> entity)
        {
            entity.HasKey(e => new {e.UserId, e.RoleId});

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}