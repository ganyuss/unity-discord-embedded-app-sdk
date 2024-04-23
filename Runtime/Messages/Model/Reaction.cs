using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class Reaction
    {
        [JsonProperty("count")]
        public int Count { [Preserve] get; [Preserve] set; }
        [JsonProperty("me")]
        public bool Me { [Preserve] get; [Preserve] set; }
        [JsonProperty("emoji")]
        public Emoji Emoji { [Preserve] get; [Preserve] set; }
    }
}