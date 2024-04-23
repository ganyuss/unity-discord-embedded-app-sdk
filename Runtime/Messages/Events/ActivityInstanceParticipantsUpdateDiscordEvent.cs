using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when the number of instance participants changes.
    /// <br /><br />
    /// No scopes required.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ActivityInstanceParticipantsUpdateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public ActivityInstanceParticipantsUpdateDiscordEventData Data { get; [Preserve] set; }
    }

    [Serializable]
    [Preserve]
    [PublicAPI]
    public class ActivityInstanceParticipantsUpdateDiscordEventData
    {
        [JsonProperty("participants")]
        public Participant[] Participants { get; [Preserve] set; }
    }
}