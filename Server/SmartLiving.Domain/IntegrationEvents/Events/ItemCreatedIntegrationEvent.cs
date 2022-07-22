using EventBus.Base.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLiving.Domain.IntegrationEvents.Events
{
    public class ItemCreatedIntegrationEvent : IntegrationEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ItemCreatedIntegrationEvent(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
