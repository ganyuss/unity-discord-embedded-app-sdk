using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when the current user object changes.
    /// <br /><br />
    /// <b>Scopes required</b>
    /// <ul>
    ///     <li><see cref="Entitlements.Identify"/></li>
    /// </ul>
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class CurrentUserUpdateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public User Data { get; [Preserve] set; }
    }
}