using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ReadyConfig
    {
        [CanBeNull]
        [JsonProperty("cdn_host")]
        public string CdnHost { [Preserve] get; [Preserve] set; }
        [JsonProperty("api_endpoint")]
        public string ApiEndpoint { [Preserve] get; [Preserve] set; }
        [JsonProperty("environment")]
        public string Environment { [Preserve] get; [Preserve] set; }
    }
}