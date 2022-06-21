using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}
