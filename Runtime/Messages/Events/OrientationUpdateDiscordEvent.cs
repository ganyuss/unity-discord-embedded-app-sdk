using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events
{
    /// <summary>
    /// Received when screen orientation changes.
    /// <br /><br />
    /// No scopes required.
    /// </summary>
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class OrientationUpdateDiscordEvent : ListenableNoParamDiscordEvent
    {
        [JsonProperty("data")]
        public OrientationUpdateDiscordEventData Data { get; [Preserve] set; }
    }
    
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class OrientationUpdateDiscordEventData
    {
        [JsonProperty("screen_orientation")]
        public OrientationType ScreenOrientation { get; [Preserve] set; }
        
        // Did not add deprecated orientation property
    }
}