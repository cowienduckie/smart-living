namespace SmartLiving.Domain.Events
{
    public class ServerMsgEvent
    {
        public string Titlte { get; set; }
        public string Msg { get; set; }

        public ServerMsgEvent(string titlte, string msg)
        {
            Titlte = titlte;
            Msg = msg;
        }
    }
}