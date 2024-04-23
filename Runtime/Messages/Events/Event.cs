using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DiscordActivitySdk.Messages.Events
{
    // Correspond to "Events" enum
    
    /// <summary>
    /// Event type, as an enum
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum Event
    {
        ERROR,
        READY,
        VOICE_STATE_UPDATE,
        SPEAKING_START,
        SPEAKING_STOP,
        ACTIVITY_LAYOUT_MODE_UPDATE,
        ORIENTATION_UPDATE,
        CURRENT_USER_UPDATE,
        ENTITLEMENT_CREATE,
        THERMAL_STATE_UPDATE,
        ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE,
    }
}