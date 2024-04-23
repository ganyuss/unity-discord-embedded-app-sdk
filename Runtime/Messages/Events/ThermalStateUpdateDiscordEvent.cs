using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when Android or iOS thermal states are surfaced to the Discord mobile app.
    /// <br /><br />
    /// No scopes required.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ThermalStateUpdateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public ThermalStateUpdateDiscordEventData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ThermalStateUpdateDiscordEventData
    {
        [JsonProperty("thermal_state")]
        public ThermalState ThermalState { get; [Preserve] set; }
    }
}