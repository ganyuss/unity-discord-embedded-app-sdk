using System;
using DiscordActivitySdk.Messages.Commands;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="GetPlatformBehaviorsDiscordCommand"/>.
    /// </summary>
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class GetPlatformBehaviorsResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public GetPlatformBehaviorsResponseData Data { get; [Preserve] set; }
    }

    [Preserve]
    [PublicAPI]
    [Serializable]
    public class GetPlatformBehaviorsResponseData
    {
        [CanBeNull]
        [JsonProperty("iosKeyboardResizesView")]
        public bool? IosKeyboardResizesView { get; [Preserve] set; }
    }
}