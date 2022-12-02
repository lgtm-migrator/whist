namespace Whist.Server.Tests
{
    internal class Event
    {
        public string Sender;

        public string Message;

        public Event(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }
}