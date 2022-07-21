using Microsoft.EntityFrameworkCore;
using SmartLiving.DeviceMVC.BusinessLogic.DataContext.Configurations;
using SmartLiving.DeviceMVC.BusinessLogic.EFCoreColumnOrder;
using SmartLiving.DeviceMVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmartLiving.DeviceMVC.BusinessLogics.DataContext
{
    public class Context : DbContext
    {
        private static long _instanceCount;

        public Context(DbContextOptions options) : base(options)
        {
            Interlocked.Increment(ref _instanceCount);
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<HouseType> HouseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurations();
            modelBuilder.CascadeAllRelationsOnDelete();

            new DeviceConfiguration();
            new HouseConfiguration();
            new AreaConfiguration();
            new DeviceTypeConfiguration();
            new HouseTypeConfiguration();
        }
    }
}
