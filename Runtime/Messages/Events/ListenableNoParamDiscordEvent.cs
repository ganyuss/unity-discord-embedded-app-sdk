using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Discord events that can be listen for without any additional information. 
    /// </summary>
    [PublicAPI]
    public abstract class ListenableNoParamDiscordEvent : DiscordEvent
    {
        
    }
}