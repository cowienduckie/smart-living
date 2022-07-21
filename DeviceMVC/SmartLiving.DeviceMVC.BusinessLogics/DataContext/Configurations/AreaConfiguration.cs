using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.DeviceMVC.Data.Entities;

namespace SmartLiving.DeviceMVC.BusinessLogic.DataContext.Configurations
{
    public class AreaConfiguration : ConfigurationBase<Area>
    {
        public override string TableName => nameof(Area);

        public override void ConfigureEntity(EntityTypeBuilder<Area> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasMany(a => a.Devices)
                .WithOne(d => d.Area)
                .HasForeignKey(d => d.AreaId);

            entity.HasOne(a => a.House)
                .WithMany(h => h.Areas)
                .HasForeignKey(a => a.HouseId);
        }
    }
}