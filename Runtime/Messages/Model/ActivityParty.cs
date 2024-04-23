using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [PublicAPI]
    [Preserve]
    public class ActivityParty
    {
        [CanBeNull]
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public int[] Size { [Preserve] get; [Preserve] set; }
    }
}