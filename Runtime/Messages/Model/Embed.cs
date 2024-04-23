using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class Embed
    {
        [CanBeNull]
        [JsonProperty("title")]
        public string Title { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("type")]
        public string Type { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("description")]
        public string Description { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("url")]
        public string Url { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("timestamp")]
        public string TimeStampString { [Preserve] get; [Preserve] set; }
        public DateTime? TimeStamp => TimeStampString != null ? DateTime.Parse(TimeStampString) : null;
        
        [CanBeNull]
        [JsonProperty("color")]
        public int? Color { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("footer")]
        public EmbedFooter Footer { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("image")]
        public Image Image { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("thumbnail")]
        public Image Thumbnail { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("video")]
        public Video Video { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("provider")]
        public EmbedProvider Provider { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("author")]
        public EmbedAuthor Author { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("fields")]
        public EmbedField[] Field { [Preserve] get; [Preserve] set; }
    }
}