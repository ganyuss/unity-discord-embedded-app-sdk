using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when a user changes the layout mode in the Discord client.
    /// <br /><br />
    /// No scopes required.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ActivityLayoutModeUpdateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public ActivityLayoutModeUpdateDiscordEventData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ActivityLayoutModeUpdateDiscordEventData
    {
        [JsonProperty("layout_mode")]
        public LayoutModeType LayoutMode { get; [Preserve] set; }
    }
}