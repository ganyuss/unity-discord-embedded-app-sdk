using System;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="SetActivityDiscordCommand"/>.
    /// </summary>
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class SetActivityResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public Activity Data { get; [Preserve] set; }
    }
}