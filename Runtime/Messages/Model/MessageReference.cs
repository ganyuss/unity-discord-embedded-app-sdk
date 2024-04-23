using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class MessageReference
    {
        [CanBeNull]
        [JsonProperty("message_id")]
        public string MessageId { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("channel_id")]
        public string ChannelId { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("guild_id")]
        public string GuildId { [Preserve] get; [Preserve] set; }
    }
}