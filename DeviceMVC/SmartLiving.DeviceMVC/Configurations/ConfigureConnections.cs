using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SmartLiving.DeviceMVC.BusinessLogics.DataContext;

namespace SmartLiving.Api.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration["ConnectionString"] ??
                             "";

            services.AddDbContextPool<Context>((serviceProvider, optionsBuilder) =>
            {
                //optionsBuilder.UseSqlite(connection);
                //optionsBuilder.ReplaceService<IMigrationsAnnotationProvider, CustomSqliteAnnotationProvider>();
                //optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomSqliteMigrationsSqlGenerator>();
                optionsBuilder.UseNpgsql(connection);
                optionsBuilder.ReplaceService<IMigrationsAnnotationProvider, CustomPostgreSqlAnnotationProvider>();
                optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomPostgreSqlMigrationsSqlGenerator>();
            });

            //services.AddSingleton(new SqliteConnection(connection));
            services.AddSingleton(new NpgsqlConnection(connection));
            return services;
        }
    }
}