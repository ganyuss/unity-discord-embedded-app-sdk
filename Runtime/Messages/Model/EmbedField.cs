using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class EmbedField
    {
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [JsonProperty("value")]
        public string Value { [Preserve] get; [Preserve] set; }
        [JsonProperty("inline")]
        public bool Inline { [Preserve] get; [Preserve] set; }
    }
}