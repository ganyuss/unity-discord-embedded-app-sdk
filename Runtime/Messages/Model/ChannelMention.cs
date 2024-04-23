using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class ChannelMention
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        [JsonProperty("guild_id")]
        public string GuildId { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("type")]
        public int Type { [Preserve] get; [Preserve] set; }
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
    }
}