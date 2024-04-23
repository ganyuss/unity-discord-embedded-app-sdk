using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class EmbedAuthor
    {
        [CanBeNull]
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("url")]
        public string Url { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("icon_url")]
        public string IconUrl { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("proxy_icon_url")]
        public string ProxyIconUrl { [Preserve] get; [Preserve] set; }
    }
}