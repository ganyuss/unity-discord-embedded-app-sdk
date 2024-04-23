using System;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.JavaScript
{
    /// <summary>
    /// The content of a window message received from the Discord app.
    /// </summary>
    [Serializable]
    public class WindowMessage
    {
        /// <summary>
        /// The content of the deserialized message.
        /// <br /><br />
        /// The payload should be in the following format:
        /// <code>
        /// [
        ///     OpCode,
        ///     DiscordEvent payload
        /// ]
        /// </code>
        /// </summary>
        /// <seealso cref="OpCode"/>
        /// <seealso cref="DiscordEvent"/>
        [NotNull] 
        [JsonProperty("data")] 
        public JToken Data { [Preserve] get; [Preserve] set; }
    }
}