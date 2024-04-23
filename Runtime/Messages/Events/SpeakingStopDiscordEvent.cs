using System;
using DiscordActivitySdk.Messages.Events.ListenParameters;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when a user in a subscribed voice channel stops speaking.
    /// <br /><br />
    /// <b>Scopes required</b>
    /// <ul>
    ///     <li><see cref="Entitlements.RpcVoiceRead"/></li>
    /// </ul>
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class SpeakingStopDiscordEvent : ListenableWithParamDiscordEvent<VoiceStateParameters>
    {
        [JsonProperty("data")]
        public SpeakingStopDiscordEventData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class SpeakingStopDiscordEventData
    {
        [CanBeNull]
        [JsonProperty("lobby_id")]
        public string LobbyId { get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("channel_id")]
        public string ChannelId { get; [Preserve] set; }
        
        [JsonProperty("user_id")]
        public string UserId { get; [Preserve] set; }
    }
}