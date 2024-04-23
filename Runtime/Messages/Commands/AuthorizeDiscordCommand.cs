using System;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{    
    /// <summary>
    /// Authorize a new client with your app.
    /// <br /><br />
    /// <b>Supported Platforms</b>
    /// <list type="table">
    ///     <item>
    ///         <term>Web</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>iOS</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>Android</term>
    ///         <description>️✅</description>
    ///     </item>
    /// </list>
    /// <br />
    /// No scopes required.
    /// </summary>
    [Serializable]
    [PublicAPI]
    public class AuthorizeDiscordCommand : FrameDiscordCommand<AuthorizeResponse>
    {
        internal override Command Command => Command.AUTHORIZE;
     
        public AuthorizeDiscordCommand([NotNull] string clientId, AuthorizeResponseType responseType,
            [NotNull] string[] scopes)
        {
            ClientId = clientId;
            Scopes = scopes;
            ResponseType = responseType;
        }
        
        [NotNull]
        [JsonProperty("client_id")]
        public string ClientId { [Preserve] get; set; }
        
        [NotNull]
        [JsonProperty("scope")]
        public string[] Scopes { [Preserve] get; set; }
        
        [JsonProperty("response_type")]
        public AuthorizeResponseType ResponseType { [Preserve] get; set; }
        
        [CanBeNull] 
        [JsonProperty("code_challenge")] 
        public string CodeChallenge { [Preserve] get; set; }
        
        [CanBeNull] 
        [JsonProperty("state")] 
        public string State { [Preserve] get; set; }

        [Preserve]
        [JsonProperty("prompt")]
        public string Prompt => "none";
    }
}