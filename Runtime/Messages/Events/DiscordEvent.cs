using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Base class for all the events sent by the Discord application. 
    /// </summary>
    [Serializable]
    [PublicAPI]
    [RequireDerived]
    public class DiscordEvent
    {
        [JsonProperty("evt")]
        public Event? EventType { get; [Preserve] set; }
        
        [JsonProperty("nonce")]
        public string Nonce { get; [Preserve] set; }
        
        [JsonProperty("cmd")]
        public string Command { get; [Preserve] set; }
    }
}