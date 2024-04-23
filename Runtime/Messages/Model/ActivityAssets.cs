using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class ActivityAssets
    {
        [CanBeNull]
        [JsonProperty("large_image", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeImage { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("large_text", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeText { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("small_image", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallImage { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("small_text", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallText { [Preserve] get; [Preserve] set; }
    }
}