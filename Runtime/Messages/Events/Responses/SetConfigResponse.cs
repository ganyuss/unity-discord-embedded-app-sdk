using System;
using DiscordActivitySdk.Messages.Commands;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// This is the response event to <see cref="SetConfigDiscordCommand"/>.
    /// </summary>
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class SetConfigResponse : DiscordEvent
    {
        [JsonProperty("data")]
        public SetConfigResponseData Data { get; [Preserve] set; }
    }
    
    [Preserve]
    [PublicAPI]
    [Serializable]
    public class SetConfigResponseData
    {
        /// <summary>
        /// I don't know why the response in undefined, so this field is Nullable, even
        /// though it is not in the SDK source
        /// </summary>
        [CanBeNull]
        [JsonProperty("user_interactive_pip")]
        public bool? UserInteractivePip { get; [Preserve] set; }
    }
}