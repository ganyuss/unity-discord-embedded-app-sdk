using System;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="AuthenticateDiscordCommand"/>.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class AuthenticateResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public AuthenticateResponseData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class AuthenticateResponseData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; [Preserve] set; }
        [JsonProperty("expires")]
        public DateTime ExpireDate { get; [Preserve] set; }
        
        [JsonProperty("scopes")]
        public string[] Scopes { get; [Preserve] set; }
        
        [JsonProperty("user")]
        public User User { get; [Preserve] set; }
        
        [JsonProperty("application")]
        public Application Application { get; [Preserve] set; }
    }
}