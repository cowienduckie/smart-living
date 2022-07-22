using EventBus.Base.Standard;

namespace SmartLiving.Domain.IntegrationEvents.Events
{
    public class ServerMsgEvent : IntegrationEvent
    {
        public ServerMsgEvent(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}