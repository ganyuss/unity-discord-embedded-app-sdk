using System;
using DiscordActivitySdk.Messages.Commands;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="AuthorizeDiscordCommand"/>.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class AuthorizeResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public AuthorizeResponseData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class AuthorizeResponseData
    {
        [JsonProperty("code")]
        public string Code { get; [Preserve] set; }
    }
}