using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Presents a modal dialog with Channel Invite UI without requiring additional OAuth scopes.
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
    [Serializable]
    [PublicAPI]
    public class OpenInviteDialogDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.OPEN_INVITE_DIALOG;
    }
}