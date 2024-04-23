using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Presents a modal dialog to share media to a channel or direct message.
    /// <br /><br />
    /// <b>Supported Platforms</b>
    /// <list type="table">
    ///     <item>
    ///         <term>Web</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>iOS</term>
    ///         <description>⛔️</description>
    ///     </item>
    ///     <item>
    ///         <term>Android</term>
    ///         <description>⛔️</description>
    ///     </item>
    /// </list>
    /// <br />
    /// No scopes required.
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class OpenShareMomentDialogDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.OPEN_SHARE_MOMENT_DIALOG;
        
        public OpenShareMomentDialogDiscordCommand([NotNull] string mediaUrl)
        {
            MediaUrl = mediaUrl;
        }
        
        [NotNull]
        [JsonProperty("mediaUrl")]
        public string MediaUrl { [Preserve] get; set; }
    }
}