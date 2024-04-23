using System;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="GetChannelPermissionsDiscordCommand"/>.
    /// </summary>
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class GetChannelPermissionsResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public GetChannelPermissionsResponseData Data { get; [Preserve] set; }

    }

    [PublicAPI]
    [Preserve]
    [Serializable]
    public class GetChannelPermissionsResponseData
    {
        [CanBeNull]
        [JsonProperty("permissions")]
        public Permission? Permissions { get; [Preserve] set; }
    }
}