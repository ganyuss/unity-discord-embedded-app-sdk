using System;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Modifies how your activity's rich presence is displayed in the Discord client.
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
    ///     <li><see cref="Entitlements.RpcActivitiesWrite"/></li>
    /// </ul>
    /// </summary>
    [Serializable]
    [PublicAPI]
    public class SetActivityDiscordCommand : FrameDiscordCommand<SetActivityResponse>
    {
        internal override Command Command => Command.SET_ACTIVITY;
        
        public SetActivityDiscordCommand([NotNull] ActivityUpdate activity)
        {
            Activity = activity;
        }
        
        [NotNull]
        [JsonProperty("activity")]
        public ActivityUpdate Activity { [Preserve] get; set; }
    }
}