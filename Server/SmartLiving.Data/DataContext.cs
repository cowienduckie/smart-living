using System.Net.Http.Headers;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartLiving.Data.Configurations;
using SmartLiving.Data.EFCoreColumnOrder;
using SmartLiving.Domain.Entities;

namespace SmartLiving.Data
{
    public class DataContext : IdentityDbContext<User, Role, string,
        IdentityUserClaim<string>,
        UserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        private static long _instanceCount;

        public DataContext(DbContextOptions options) : base(options)
        {
            Interlocked.Increment(ref _instanceCount);
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AutoMessage> AutoMessages { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<CommandType> CommandTypes { get; set; }
        public virtual DbSet<DeviceData> DeviceData { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<HouseType> HouseTypes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileDevice> ProfileDevices { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SharedWith> SharedWith { get; set; }
        public virtual DbSet<DeviceCommandType> DeviceCommandTypes { get; set; }        
        public virtual DbSet<DeviceTypeCommandType> DeviceTypeCommandTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            new AreaConfiguration();
            new AutoMessageConfiguration();
            new CommandConfiguration();
            new CommandTypeConfiguration();
            new DeviceDataConfiguration();
            new DeviceTypeConfiguration();
            new HouseTypeConfiguration();
            new ProfileConfiguration();
            new ProfileDeviceConfiguration();
            new ScheduleConfiguration();
            new SharedWithConfiguration();
            new DeviceCommandTypeConfiguration(modelBuilder.Entity<DeviceCommandType>());
            new DeviceTypeCommandTypeConfiguration(modelBuilder.Entity<DeviceTypeCommandType>());

            //Create DbSet for Role and UserRole with keys
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityRole<string>>().HasKey(r => r.Id);
        }
    }
}