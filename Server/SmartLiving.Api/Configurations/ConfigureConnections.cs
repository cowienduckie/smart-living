using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartLiving.Api.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("LocalSqliteConnection") ??
                             "Data Source=ClothingShop.db";

            services.AddDbContextPool<DataContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlite(connection);
                optionsBuilder.ReplaceService<IMigrationsAnnotationProvider, CustomPostgreSqlAnnotationProvider>();
                optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomPostgreSqlMigrationsSqlGenerator>();
            });

            services.AddSingleton(new SqlConnection(connection));

            services.AddSingleton(new DbInfo(connection));

            return services;
        }
    }
}
