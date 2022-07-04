using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class HouseConfiguration : ConfigurationBase<House>
    {
        public override string TableName => nameof(House);

        public override void ConfigureEntity(EntityTypeBuilder<House> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(h => h.Devices)
                .WithOne(d => d.House)
                .HasForeignKey(d => d.HouseId);

            entity.HasOne(h => h.User)
                .WithMany(u => u.Houses)
                .HasForeignKey(h => h.UserId);

            entity.HasMany(h => h.Areas)
                .WithOne(a => a.House)
                .HasForeignKey(a => a.HouseId);

            entity.HasOne(h => h.HouseType)
                .WithMany(ht => ht.Houses)
                .HasForeignKey(h => h.HouseTypeId);
        }
    }
}