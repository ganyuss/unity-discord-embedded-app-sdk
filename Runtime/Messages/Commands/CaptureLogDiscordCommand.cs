using System;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Forward logs to your own logger.
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
    [PublicAPI]
    [Serializable]
    public class CaptureLogDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.CAPTURE_LOG;
        
        public CaptureLogDiscordCommand(ConsoleLevel level, [NotNull] string message)
        {
            Message = message;
            Level = level;
        }

        [NotNull]
        [JsonProperty("message")]
        public string Message { [Preserve] get; set; }
        
        [JsonProperty("level")]
        public ConsoleLevel Level { [Preserve] get; set; }
    }
}