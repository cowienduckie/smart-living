using EventBus.Base.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Events;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Handlers;
using System.Collections.Generic;

namespace SmartLiving.DeviceMVC.Extenstions
{
    public static class EventBusExtension
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers()
        {
            return new List<IIntegrationEventHandler>
            {
                new ItemCreatedIntegrationEventHandler()
            };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ItemCreatedIntegrationEvent, ItemCreatedIntegrationEventHandler>();

            return app;
        }
    }
}
