using System.Collections.Generic;
using EventBus.Base.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmartLiving.Domain.IntegrationEvents.Events;
using SmartLiving.Domain.IntegrationEvents.Handlers;

namespace SmartLiving.Api.Extensions
{
    public static class EventBusExtension
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers()
        {
            return new List<IIntegrationEventHandler>
            {
                new DeviceGatewayMsgEventHandler()
            };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<DeviceGatewayMsgEvent, DeviceGatewayMsgEventHandler>();

            return app;
        }
    }
}