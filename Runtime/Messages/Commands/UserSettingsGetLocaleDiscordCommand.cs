using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Returns the current user's locale.
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
    /// <b>Scopes required</b>
    /// <ul>
    ///     <li><see cref="Entitlements.Identify"/></li>
    /// </ul>
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class UserSettingsGetLocaleDiscordCommand : FrameDiscordCommand<UserSettingsGetLocaleResponse>
    {
        internal override Command Command => Command.USER_SETTINGS_GET_LOCALE;
    }
}