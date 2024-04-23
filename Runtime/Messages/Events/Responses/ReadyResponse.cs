using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// Internal, response to handshake command.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ReadyResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public ReadyResponseData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ReadyResponseData
    {
        [JsonProperty("v")]
        public int Version { get; [Preserve] set; }
        
        [JsonProperty("config")]
        public ReadyConfig Config { get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("user")]
        public User User { get; [Preserve] set; }
    }
}