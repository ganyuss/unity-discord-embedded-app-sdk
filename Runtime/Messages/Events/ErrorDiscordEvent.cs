using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    [Serializable]
    [Preserve]
    internal class ErrorDiscordEvent : DiscordEvent
    {
        [JsonProperty("data")]
        public ErrorDiscordEventData Data { get; [Preserve] set; }

        public Exception ToException()
        {
            if (Data.ErrorMessage == null)
                return new Exception($"Error code {Data.ErrorCode} from Discord app");

            return new Exception($"Error [{Data.ErrorCode}] \"{Data.ErrorMessage}\" from Discord app");
        }
    }

    [Serializable]
    [Preserve]
    internal class ErrorDiscordEventData
    {
        [JsonProperty("code")]
        public int ErrorCode { get; [Preserve] set; }
        
        [CanBeNull] 
        [JsonProperty("message")] 
        public string ErrorMessage { get; [Preserve] set; }
    }
}