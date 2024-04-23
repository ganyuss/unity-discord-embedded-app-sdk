using System;
using DiscordActivitySdk.Messages.Events;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    [Serializable]
    internal class UnsubscribeDiscordCommand : DiscordCommand<SubscribeResponse>
    {
        internal override OpCode OpCode => OpCode.FRAME;
        
        [JsonProperty("cmd")]
        [Preserve]
        public Command Command => Command.UNSUBSCRIBE;
     
        public UnsubscribeDiscordCommand(Event @event)
        {
            Event = @event;
        }
        
        [JsonProperty("evt")]
        public Event Event { [Preserve] get; set; }
        
        [JsonProperty("args")] 
        [CanBeNull]
        public object Args { [Preserve] get; set; }

        [JsonProperty("nonce")] 
        [Preserve]
        internal Guid? SerializedGuid => Guid;
    }
}