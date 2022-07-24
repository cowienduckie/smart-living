using Microsoft.Extensions.DependencyInjection;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.BusinessLogics.Services;

namespace SmartLiving.DeviceMVC.Configurations
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();

            services.AddHostedService<MessageService>();
        }
    }
}