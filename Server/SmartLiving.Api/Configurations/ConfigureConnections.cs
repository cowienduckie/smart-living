using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SmartLiving.Data;
using SmartLiving.Domain.DbInfo;

namespace SmartLiving.Api.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration["ConnectionStrings:DigitalOcean"] ??
                             "";

            services.AddDbContextPool<DataContext>((serviceProvider, optionsBuilder) =>
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

            services.AddSingleton(new DbInfo(connection));

            return services;
        }
    }
}