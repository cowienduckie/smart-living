using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class HouseTypeConfiguration : ConfigurationBase<HouseType>
    {
        public override string TableName => nameof(HouseType);

        public override void ConfigureEntity(EntityTypeBuilder<HouseType> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.HasMany(ht => ht.Houses)
                .WithOne(h => h.HouseType)
                .HasForeignKey(h => h.HouseTypeId);
        }
    }
}