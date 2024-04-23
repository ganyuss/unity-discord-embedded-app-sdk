using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class EmbedProvider
    {
        [CanBeNull]
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("url")]
        public string Url { [Preserve] get; [Preserve] set; }
    }
}