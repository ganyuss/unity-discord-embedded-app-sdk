using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.ListenParameters
{
    /// <summary>
    /// Parameter required to listen to <see cref="VoiceStateUpdateDiscordEvent"/>,
    /// <see cref="SpeakingStartDiscordEvent"/> and <see cref="SpeakingStopDiscordEvent"/>
    /// </summary>
    [Serializable]
    public class VoiceStateParameters
    {
        public VoiceStateParameters([NotNull] string channelId)
        {
            ChannelId = channelId;
        }

        [NotNull] 
        [JsonProperty("channel_id")] 
        public string ChannelId { [Preserve] get; set; }
    }
}