using System;
using System.Threading.Tasks;
using EventBus.Base.Standard;
using SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Events;

namespace SmartLiving.DeviceMVC.BusinessLogics.IntegrationEvents.Handlers
{
    public class ItemCreatedIntegrationEventHandler : IIntegrationEventHandler<ItemCreatedIntegrationEvent>
    {
        public Task Handle(ItemCreatedIntegrationEvent @event)
        {
            var itemTitle = @event.Title;
            var itemDescription = @event.Description;

            Console.WriteLine($"{itemTitle} : {itemDescription}");
            return Task.CompletedTask;
        }
    }
}