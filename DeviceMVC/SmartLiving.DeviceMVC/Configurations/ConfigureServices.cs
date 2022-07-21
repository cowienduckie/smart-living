using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;

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
    }
}