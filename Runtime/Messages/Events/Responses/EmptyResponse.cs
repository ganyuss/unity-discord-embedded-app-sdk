using System;
using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Events.Responses
{
    /// <summary>
    /// A response to a command without any payload. 
    /// </summary>
    [PublicAPI]
    [Serializable]
    [Preserve]
    public class EmptyResponse : DiscordEvent
    {
        
    }
}