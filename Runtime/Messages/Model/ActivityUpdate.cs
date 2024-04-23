using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class ActivityUpdate
    {
        [CanBeNull]
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("timestamps", NullValueHandling = NullValueHandling.Ignore)]
        public TimeFrame TimeStamps { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("assets", NullValueHandling = NullValueHandling.Ignore)]
        public ActivityAssets Assets { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("party", NullValueHandling = NullValueHandling.Ignore)]
        public ActivityParty Party { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("secrets", NullValueHandling = NullValueHandling.Ignore)]
        public ActivitySecrets Secrets { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("instance", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Instance { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int? Type { [Preserve] get; [Preserve] set; }
    }
}