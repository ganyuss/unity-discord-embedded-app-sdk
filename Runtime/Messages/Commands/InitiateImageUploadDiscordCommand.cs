using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Presents the file upload flow in the Discord client.
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
    public class InitiateImageUploadDiscordCommand : FrameDiscordCommand<InitiateImageUploadResponse>
    {
        internal override Command Command => Command.INITIATE_IMAGE_UPLOAD;
    }
}