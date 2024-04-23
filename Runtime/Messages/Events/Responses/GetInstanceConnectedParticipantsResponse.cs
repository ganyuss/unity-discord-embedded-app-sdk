using System;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="GetInstanceConnectedParticipantsDiscordCommand"/>.
    /// </summary>
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class GetInstanceConnectedParticipantsResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public GetInstanceConnectedParticipantsData Data { get; [Preserve] set; }
    }
    
    
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class GetInstanceConnectedParticipantsData
    {
        [JsonProperty("participants")]
        public Participant[] Participants { get; [Preserve] set; }
    }
}