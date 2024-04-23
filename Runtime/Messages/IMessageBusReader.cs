using DiscordActivitySdk.Messages.Events;

namespace DiscordActivitySdk.Messages
{
    public interface IMessageBusReader
    {
        public bool ToBeRemoved { get; }
        
        public void AddEventToRead(DiscordEvent discordEvent);
    }
}