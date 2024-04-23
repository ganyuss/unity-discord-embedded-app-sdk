using System;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class GetChannelResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public GetChannelResponseData Data { [Preserve] get; [Preserve] set; }
    }
    
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class GetChannelResponseData
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("type")]
        public ChannelType Type { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("guild_id")]
        public string GuildId { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("topic")]
        public string Topic { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("bitrate")]
        public double? BitRate { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("user_limit")]
        public int? UserLimit { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("position")]
        public int? Position { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("voice_states")]
        public VoiceState[] VoiceStates { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("messages")]
        public Message[] Messages { [Preserve] get; [Preserve] set; }
    }
}