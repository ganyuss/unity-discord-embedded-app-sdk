using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Returns information about supported platform behaviors.
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
    public class GetPlatformBehaviorsDiscordCommand : FrameDiscordCommand<GetPlatformBehaviorsResponse>
    {
        internal override Command Command => Command.GET_PLATFORM_BEHAVIORS;
    }
}