using System;
using DiscordActivitySdk.Messages.Events.ListenParameters;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when a user's voice state changes in a subscribed voice channel (mute, volume, etc).
    /// <br /><br />
    /// <b>Scopes required</b>
    /// <ul>
    ///     <li><see cref="Entitlements.RpcVoiceRead"/></li>
    /// </ul>
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class VoiceStateUpdateDiscordEvent : ListenableWithParamDiscordEvent<VoiceStateParameters>
    {
        [JsonProperty("data")]
        public UserVoiceState Data { get; [Preserve] set; }
    }
}