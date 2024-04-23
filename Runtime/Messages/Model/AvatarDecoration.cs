using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class AvatarDecoration
    {
        [JsonProperty("asset")]
        public string Asset { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("skuId")]
        public string SkuId { [Preserve] get; [Preserve] set; }
    }
}