using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SmartLiving.Data.Repositories;
using SmartLiving.Domain.RepositoryInterfaces;
using SmartLiving.Domain.Supervisors;
using SmartLiving.Domain.Supervisors.Interfaces;

namespace SmartLiving.Api.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }

        public static void ConfigureSupervisor(this IServiceCollection services)
        {
            services.AddScoped<ISupervisor, Supervisor>();
        }

        public static void AddMiddleware(this IServiceCollection services)
        {
            // services.AddMvc().AddNewtonsoftJson(options =>
            // {
            //     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // });
        }

        public static void AddLogging(this IServiceCollection services)
        {
            services.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
            );
        }

        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCaching();
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddNewtonsoft(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }
    }
}
