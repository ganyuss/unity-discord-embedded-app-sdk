using System;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Commands
{
    internal static class CommandTypeUtility
    {
        [NotNull]
        [Pure]
        public static Type GetAssociatedResponseType(this Command command)
        {
            switch (command)
            {
                case Command.AUTHORIZE:
                    return typeof(AuthorizeResponse);
                case Command.AUTHENTICATE:
                    return typeof(AuthenticateResponse);
                
                case Command.SUBSCRIBE:
                    return typeof(SubscribeResponse);
                case Command.UNSUBSCRIBE:
                    return typeof(SubscribeResponse);
                
                case Command.GET_ACTIVITY_INSTANCE_CONNECTED_PARTICIPANTS:
                    return typeof(GetInstanceConnectedParticipantsResponse);
                case Command.GET_CHANNEL:
                    return typeof(GetChannelResponse);
                case Command.GET_CHANNEL_PERMISSIONS:
                    return typeof(GetChannelPermissionsResponse);
                case Command.GET_PLATFORM_BEHAVIORS:
                    return typeof(GetPlatformBehaviorsResponse);
                case Command.USER_SETTINGS_GET_LOCALE:
                    return typeof(UserSettingsGetLocaleResponse);
                
                case Command.SET_ACTIVITY:
                    return typeof(SetActivityResponse);
                case Command.SET_CONFIG:
                    return typeof(SetConfigResponse);
                case Command.SET_ORIENTATION_LOCK_STATE:
                    return typeof(EmptyResponse);
                
                case Command.OPEN_EXTERNAL_LINK:
                    return typeof(EmptyResponse);
                case Command.OPEN_INVITE_DIALOG:
                    return typeof(EmptyResponse);
                case Command.OPEN_SHARE_MOMENT_DIALOG:
                    return typeof(EmptyResponse);
                
                case Command.INITIATE_IMAGE_UPLOAD:
                    return typeof(InitiateImageUploadResponse);
                case Command.ENCOURAGE_HW_ACCELERATION:
                    return typeof(EmptyResponse);
                case Command.CAPTURE_LOG:
                    return typeof(EmptyResponse);
                
                
                case Command.GET_CHANNELS:
                case Command.GET_ENTITLEMENTS:
                case Command.GET_ENTITLEMENTS_EMBEDDED:
                case Command.GET_GUILD:
                case Command.GET_GUILDS:
                case Command.GET_SKUS:
                case Command.GET_SKUS_EMBEDDED:
                    
                case Command.SET_CERTIFIED_DEVICES:
                    
                case Command.CAPTURE_SHORTCUT:
                case Command.SELECT_TEXT_CHANNEL:
                case Command.SELECT_VOICE_CHANNEL:
                case Command.START_PURCHASE:
                case Command.SEND_ANALYTICS_EVENT:
                    throw new NotImplementedException("Command response not implemented");
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, "Command response type not found");
            }
        }
    }
}