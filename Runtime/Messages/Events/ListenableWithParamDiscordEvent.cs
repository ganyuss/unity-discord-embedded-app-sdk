using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Discord events that can be listen for only by providing additional information. 
    /// </summary>
    /// <typeparam name="TParam">The type of additional information necessary for listening.</typeparam>
    [PublicAPI]
    public abstract class ListenableWithParamDiscordEvent<TParam> : DiscordEvent
    {

    }
}