using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    public class Application
    {
        [JsonProperty("name")]
        public string Name { [Preserve] get; [Preserve] set; }
        [JsonProperty("description")]
        public string Description { [Preserve] get; [Preserve] set; }
        [JsonProperty("summary")]
        public string Summary { [Preserve] get; [Preserve] set; }
        [JsonProperty("icon")]
        public string Icon { [Preserve] get; [Preserve] set; }
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("is_monetized")]
        public bool IsMonetized { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("max_participants")]
        [CanBeNull] 
        public int? MaxParticipants { [Preserve] get; [Preserve] set; }
        [JsonProperty("type")] 
        [CanBeNull] 
        public object Type { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("bot")]
        public User ApplicationBot { [Preserve] get; [Preserve] set; }
        [JsonProperty("bot_public")]
        public bool ApplicationBotPublic { [Preserve] get; [Preserve] set; }
        [JsonProperty("bot_require_code_grant")]
        public bool ApplicationBotRequireCodeGrant { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("verify_key")]
        public string VerifyKey { [Preserve] get; [Preserve] set; }

        [JsonProperty("flags")]
        public int Flags { [Preserve] get; [Preserve] set; }
        [JsonProperty("hook")]
        public bool Hook { [Preserve] get; [Preserve] set; }
    }
}