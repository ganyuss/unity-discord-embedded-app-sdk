using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Allows for opening an external link from within the Discord client.
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
    ///         <description>✅</description>
    ///     </item>
    /// </list>
    /// <br />
    /// No scopes required.
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class OpenExternalLinkDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.OPEN_EXTERNAL_LINK;
        
        public OpenExternalLinkDiscordCommand([NotNull] string targetUrl)
        {
            TargetUrl = targetUrl;
        }
        
        [NotNull]
        [JsonProperty("url")] 
        public string TargetUrl { [Preserve] get; set; }
    }
}