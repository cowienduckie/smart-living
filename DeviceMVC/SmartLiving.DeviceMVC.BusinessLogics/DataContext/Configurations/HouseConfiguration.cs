using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.DeviceMVC.Data.Entities;

namespace SmartLiving.DeviceMVC.BusinessLogic.DataContext.Configurations
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

            entity.HasMany(h => h.Areas)
                .WithOne(a => a.House)
                .HasForeignKey(a => a.HouseId);

            entity.HasOne(h => h.HouseType)
                .WithMany(ht => ht.Houses)
                .HasForeignKey(h => h.HouseTypeId);
        }
    }
}