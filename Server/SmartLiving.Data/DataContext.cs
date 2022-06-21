using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Data.Configurations;
using SmartLiving.Data.EFCoreColumnOrder;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole, string,
                                                IdentityUserClaim<string>,
                                                IdentityUserRole<string>,
                                                IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>,
                                                IdentityUserToken<string>>
    {
        private static long _instanceCount;

        public DataContext(DbContextOptions options) : base(options)
        {
            Interlocked.Increment(ref _instanceCount);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Categories { get; set; }
        public virtual DbSet<House> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet")) entityType.SetTableName(tableName.Substring(6));
            }

            modelBuilder.ApplyAllConfigurations();
            modelBuilder.CascadeAllRelationsOnDelete();

            new UserConfiguration(modelBuilder.Entity<User>());
            new DeviceConfiguration();
            new HouseConfiguration();
        }
    }
}
