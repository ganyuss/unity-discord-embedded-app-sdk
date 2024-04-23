using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class MessageApplication
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [JsonProperty("description")]
        public string Description { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("cover_image")]
        public string CoverImage { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("icon")]
        public string Icon { [Preserve] get; [Preserve] set; }
    }
}