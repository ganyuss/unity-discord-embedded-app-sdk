using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class User
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        [JsonProperty("username")]
        public string Username { [Preserve] get; [Preserve] set; }
        [JsonProperty("discriminator")]
        public string Discriminator { [Preserve] get; [Preserve] set; }
        
        [CanBeNull] 
        [JsonProperty("global_name")]
        public string GlobalName { [Preserve] get; [Preserve] set; }
        
        
        [CanBeNull]
        [JsonProperty("avatar")]
        public string Avatar { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("avatar_decoration_data")]
        public AvatarDecoration AvatarDecoration { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("bot")]
        public bool IsBot { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("flags")]
        public int? Flags { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("premium_type")]
        public int? PremiumType { [Preserve] get; [Preserve] set; }
    }
}