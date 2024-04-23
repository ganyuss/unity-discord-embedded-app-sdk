using System;
using DiscordActivitySdk.Messages.Commands;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="UserSettingsGetLocaleDiscordCommand"/>.
    /// </summary>
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class UserSettingsGetLocaleResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public UserSettingsGetLocaleResponseData Data { get; [Preserve] set; }
    }

    [Preserve]
    [PublicAPI]
    [Serializable]
    public class UserSettingsGetLocaleResponseData
    {
        [JsonProperty("locale")]
        public string Locale { get; [Preserve] set; }
    }
}