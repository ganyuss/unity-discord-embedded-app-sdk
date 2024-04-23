using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    [Serializable]
    internal class HandshakeDiscordCommand : DiscordCommand<ReadyResponse>
    {
        internal override OpCode OpCode => OpCode.HANDSHAKE;

        internal override Guid? Guid => null;
        
        public HandshakeDiscordCommand(int version, [NotNull] string clientId, [NotNull] string frameId)
        {
            Version = version;
            ClientId = clientId;
            FrameId = frameId;
        }
        
        [JsonProperty("v")]
        public int Version { [Preserve] get; set; }
        
        [NotNull] 
        [JsonProperty("client_id")] 
        public string ClientId { [Preserve] get; set; }
        
        [NotNull] 
        [JsonProperty("frame_id")]
        public string FrameId { [Preserve] get; set; }
    }
}