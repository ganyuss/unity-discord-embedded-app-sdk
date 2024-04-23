using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Authenticate an existing client with your app.
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
    public class AuthenticateDiscordCommand : FrameDiscordCommand<AuthenticateResponse>
    {
        internal override Command Command => Command.AUTHENTICATE;
        
        public AuthenticateDiscordCommand([NotNull] string accessToken)
        {
            AccessToken = accessToken;
        }
       
        [NotNull]
        [JsonProperty("access_token")] 
        public string AccessToken { [Preserve] get; set; }
    }
}