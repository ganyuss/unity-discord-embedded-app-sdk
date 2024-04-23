using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class Emoji
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("roles")]
        public string[] Roles { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("user")]
        public User User { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("require_colons")]
        public bool? RequireColons { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("managed")]
        public bool? Managed { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("animated")]
        public bool? Animated { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("available")]
        public bool? Available { [Preserve] get; [Preserve] set; }
    }
}