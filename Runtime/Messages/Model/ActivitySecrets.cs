using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class ActivitySecrets
    {
        [CanBeNull]
        [JsonProperty("join", NullValueHandling = NullValueHandling.Ignore)]
        public string Join { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("match", NullValueHandling = NullValueHandling.Ignore)]
        public string Match { [Preserve] get; [Preserve] set; }
    }
}