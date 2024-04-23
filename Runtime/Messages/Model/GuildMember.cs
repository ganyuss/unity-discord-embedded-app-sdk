using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class GuildMember
    {
        [JsonProperty("user")]
        public User User { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("nick")]
        public string NickName { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("roles")]
        public string[] Roles { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("joined_at")]
        public string JoinedAtString { [Preserve] get; [Preserve] set; }
        public DateTime JoinedAt => DateTime.Parse(JoinedAtString);
        
        [JsonProperty("deaf")]
        public bool Deaf { [Preserve] get; [Preserve] set; }
        [JsonProperty("mute")]
        public bool Mute { [Preserve] get; [Preserve] set; }
    }
}