using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class VoiceState
    {
        [JsonProperty("mute")]
        public bool Mute { [Preserve] get; [Preserve] set; }
        [JsonProperty("deaf")]
        public bool Deaf { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("self_mute")]
        public bool SelfMute { [Preserve] get; [Preserve] set; }
        [JsonProperty("self_deaf")]
        public bool SelfDeaf { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("suppress")]
        public bool Suppress { [Preserve] get; [Preserve] set; }
        
    }
}