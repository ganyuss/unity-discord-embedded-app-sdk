using System;
using DiscordActivitySdk.Messages.Commands;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="InitiateImageUploadDiscordCommand"/>.
    /// </summary>
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class InitiateImageUploadResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public InitiateImageUploadResponseData Data { get; [Preserve] set; }
    }

    [PublicAPI]
    [Preserve]
    [Serializable]
    public class InitiateImageUploadResponseData
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; [Preserve] set; }
    }
}