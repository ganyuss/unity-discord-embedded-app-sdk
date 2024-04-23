using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class MessageActivity
    {
        [JsonProperty("type")]
        public int Type { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("party_id")]
        public string PartyId { [Preserve] get; [Preserve] set; }
    }
}