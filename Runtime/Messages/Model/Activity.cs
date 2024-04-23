using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class Activity
    {
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [JsonProperty("type")]
        public long Type { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("url")]
        public string Url { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("created_at")]
        public long? CreatedAtUnix { [Preserve] get; [Preserve] set; }
        public DateTime? CreatedAt => CreatedAtUnix != null ? new DateTime(CreatedAtUnix.Value) : null;
        
        [CanBeNull]
        [JsonProperty("timestamps")]
        public TimeFrame TimeStamps { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("application_id")]
        public string ApplicationId { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("details")]
        public string Details { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("state")]
        public string State { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("emoji")]
        public Emoji Emoji { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("party")]
        public ActivityParty Party { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("assets")]
        public ActivityAssets Assets { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("secrets")]
        public ActivitySecrets Secrets { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("instance")]
        public bool? Instance { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("flags")]
        public long? Flags { [Preserve] get; [Preserve] set; }
    }
}