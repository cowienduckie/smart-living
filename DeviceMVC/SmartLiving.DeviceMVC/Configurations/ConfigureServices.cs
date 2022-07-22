using EventBus.Base.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Extensions;

namespace SmartLiving.DeviceMVC.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
        }

        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqOptions = configuration.GetSection("RabbitMq_SmartLiving").Get<RabbitMqOptions>();

            services.AddRabbitMqConnection(rabbitMqOptions);
            services.AddRabbitMqRegistration(rabbitMqOptions);
            services.AddEventBusHandling(EventBusExtension.GetHandlers());
        }
    }
}