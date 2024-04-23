using System;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Base class for commands to send to the Discord application. 
    /// </summary>
    /// <typeparam name="TResponseType">The type of the response to this command.</typeparam>
    [PublicAPI]
    public abstract class DiscordCommand<TResponseType> where TResponseType : DiscordEvent
    {
        [JsonIgnore] 
        internal abstract OpCode OpCode { get; }
        
        [JsonIgnore]
        internal virtual Guid? Guid { get; } = System.Guid.NewGuid();
    }
}
