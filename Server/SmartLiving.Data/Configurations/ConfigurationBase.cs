using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data.Configurations
{
    public abstract class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual string SchemaName { get; } = "dbo";

        public abstract string TableName { get; }

        public virtual void Configure(EntityTypeBuilder<TEntity> entity)
        {
            entity.ToTable(TableName, SchemaName);

            ConfigureEntity(entity);

            entity.Property(e => e.CreateTime)
                .HasColumnOrder(997);

            entity.Property(e => e.LastModified)
                .HasColumnOrder(998);
            entity.Property(e => e.IsDelete)
                .HasColumnOrder(999);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> entity);
    }
}