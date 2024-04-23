using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Presents a modal dialog to allow enabling of hardware acceleration.
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
    public class EncourageHardwareAccelerationDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.ENCOURAGE_HW_ACCELERATION;
    }
}