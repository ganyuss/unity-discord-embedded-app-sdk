using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class Video
    {
        [CanBeNull]
        [JsonProperty("url")]
        public string Url { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("height")]
        public int? Height { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("width")]
        public int? Width { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        public Vector2Int? ImageSize => Width != null && Height != null 
            ? new Vector2Int(Width.Value, Height.Value) 
            : null;
    }
}