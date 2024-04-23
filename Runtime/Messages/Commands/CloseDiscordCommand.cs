using System;
using DiscordActivitySdk.Messages.Events.Responses;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    [Serializable]
    public class CloseDiscordCommand : DiscordCommand<EmptyResponse>
    {
        public CloseDiscordCommand(RPCCloseCodes code, string message)
        {
            Code = code;
            Message = message;
        }

        internal override OpCode OpCode => OpCode.CLOSE;
        
        [JsonProperty("code")]
        public RPCCloseCodes Code { [Preserve] get; set; }
        
        [JsonProperty("message")] 
        public string Message { [Preserve] get; set; }
        
        [Preserve]
        [JsonProperty("nonce")] 
        internal Guid? SerializedGuid => Guid;
    }
}