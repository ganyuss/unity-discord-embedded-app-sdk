using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Set whether or not the PIP (picture-in-picture) is interactive.
    /// <br /><br />
    /// <b>Supported Platforms</b>
    /// <list type="table">
    ///     <item>
    ///         <term>Web</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>iOS</term>
    ///         <description>⛔</description>
    ///     </item>
    ///     <item>
    ///         <term>Android</term>
    ///         <description>⛔</description>
    ///     </item>
    /// </list>
    /// <br />
    /// No scopes required.
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class SetConfigDiscordCommand : FrameDiscordCommand<SetConfigResponse>
    {
        internal override Command Command => Command.SET_CONFIG;
        
        public SetConfigDiscordCommand(bool userInteractivePip)
        {
            UserInteractivePip = userInteractivePip;
        }

        [JsonProperty("user_interactive_pip")]
        public bool UserInteractivePip { [Preserve] get; set; }
    }
}