using System;
using System.Threading.Tasks;
using EventBus.Base.Standard;
using SmartLiving.Domain.IntegrationEvents.Events;

namespace SmartLiving.Domain.IntegrationEvents.Handlers
{
    public class DeviceGatewayMsgEventHandler : IIntegrationEventHandler<DeviceGatewayMsgEvent>
    {
        public Task Handle(DeviceGatewayMsgEvent @event)
        {
            var itemTitle = @event.Title;
            var itemDescription = @event.Description;

            Console.WriteLine($"{itemTitle} : {itemDescription}");
            return Task.CompletedTask;
        }
    }
}