using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class UserVoiceState
    {
        [JsonProperty("mute")]
        public bool Mute { [Preserve] get; [Preserve] set; }
        [JsonProperty("nick")]
        public string Nickname { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("user")]
        public User User { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("volume")]
        public float Volume { [Preserve] get; [Preserve] set; }
    }
}