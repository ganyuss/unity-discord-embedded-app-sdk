using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DiscordActivitySdk.Messages.Commands
{
    // Correspond to "Commands" enum
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    internal enum Command
    {
        AUTHORIZE,
        AUTHENTICATE,
        GET_GUILDS,
        GET_GUILD,
        GET_CHANNEL,
        GET_CHANNELS,
        SELECT_VOICE_CHANNEL,
        SELECT_TEXT_CHANNEL,
        SUBSCRIBE,
        UNSUBSCRIBE,
        CAPTURE_SHORTCUT,
        SET_CERTIFIED_DEVICES,
        SET_ACTIVITY,
        GET_SKUS,
        GET_ENTITLEMENTS,
        GET_SKUS_EMBEDDED,
        GET_ENTITLEMENTS_EMBEDDED,
        START_PURCHASE,
        SET_CONFIG,
        SEND_ANALYTICS_EVENT,
        USER_SETTINGS_GET_LOCALE,
        OPEN_EXTERNAL_LINK,
        ENCOURAGE_HW_ACCELERATION,
        CAPTURE_LOG,
        SET_ORIENTATION_LOCK_STATE,
        OPEN_INVITE_DIALOG,
        GET_PLATFORM_BEHAVIORS,
        GET_CHANNEL_PERMISSIONS,
        OPEN_SHARE_MOMENT_DIALOG,
        INITIATE_IMAGE_UPLOAD,
        GET_ACTIVITY_INSTANCE_CONNECTED_PARTICIPANTS,
    }
}