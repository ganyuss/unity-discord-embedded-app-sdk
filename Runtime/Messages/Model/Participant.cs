using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class Participant : User
    {
        [CanBeNull]
        [JsonProperty("nickname")]
        public string Nickname { [Preserve] get; [Preserve] set; }
    }
}