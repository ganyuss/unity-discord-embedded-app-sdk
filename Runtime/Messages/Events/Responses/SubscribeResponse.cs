using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// Internal, response to subscribe or unsubscribe command.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class SubscribeResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public SubscribeResponseData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class SubscribeResponseData
    {
        [JsonProperty("evt")]
        public Event Event { get; [Preserve] set; }
    }
}