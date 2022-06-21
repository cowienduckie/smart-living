using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public class DeviceConfiguration : ConfigurationBase<Device>
    {
        public override string TableName => nameof(Device);

        public override void ConfigureEntity(EntityTypeBuilder<Device> entity)
        {
            entity.HasKey(e => new {e.Id});

            entity.HasOne(d => d.House)
                .WithMany(h => h.Devices)
                .HasForeignKey(d => d.HouseId);
        }
    }
}
