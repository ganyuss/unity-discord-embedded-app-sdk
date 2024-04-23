using System;
using DiscordActivitySdk.Messages.Events;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Internal, Discord command that is sent with the <c>FRAME</c> <see cref="OpCode"/>.
    /// </summary>
    [Serializable]
    public abstract class FrameDiscordCommand<TResponse> : DiscordCommand<TResponse> where TResponse : DiscordEvent
    {
        internal override OpCode OpCode => OpCode.FRAME;
        
        [JsonIgnore] 
        internal abstract Command Command { [Preserve] get; }
    }
}