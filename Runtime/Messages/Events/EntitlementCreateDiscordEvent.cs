using System;
using DiscordActivitySdk.Messages.Model;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// This class is internal because the feature is not available yet (2024-04-13)
    /// </summary>
    [Serializable]
    [Preserve]
    internal class EntitlementCreateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public EntitlementCreateDiscordEventData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    internal class EntitlementCreateDiscordEventData
    {
        [JsonProperty("entitlement")]
        public Entitlement Entitlement { get; [Preserve] set; }
    }
}