using System;
using EventBus.Base.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Extenstions;

namespace SmartLiving.Api.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddEventBusRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqOptions = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>();

            services.AddRabbitMqConnection(rabbitMqOptions);
            services.AddRabbitMqRegistration(rabbitMqOptions);
            services.AddEventBusHandling(EventBusExtension.GetHandlers());

        }
    }
}