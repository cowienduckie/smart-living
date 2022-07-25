namespace SmartLiving.Domain.Events
{
    public class ServerMsgEvent
    {
        public string Title { get; set; }
        public string Msg { get; set; }

        public ServerMsgEvent(string title, string msg)
        {
            Title = title;
            Msg = msg;
        }
    }
}