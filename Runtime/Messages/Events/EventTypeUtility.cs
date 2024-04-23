using System;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Events
{
    internal static class EventTypeUtility
    {
        [NotNull]
        public static Type GetAssociatedClassType(this Event eventType)
        {
            switch (eventType)
            {
                case Event.ERROR:
                    return typeof(ErrorDiscordEvent);
                case Event.READY:
                    return typeof(ReadyResponse);
                case Event.VOICE_STATE_UPDATE:
                    return typeof(VoiceStateUpdateDiscordEvent);
                case Event.SPEAKING_START:
                    return typeof(SpeakingStartDiscordEvent);
                case Event.SPEAKING_STOP:
                    return typeof(SpeakingStopDiscordEvent);
                case Event.ACTIVITY_LAYOUT_MODE_UPDATE:
                    return typeof(ActivityLayoutModeUpdateDiscordEvent);
                case Event.ORIENTATION_UPDATE:
                    return typeof(OrientationUpdateDiscordEvent);
                case Event.CURRENT_USER_UPDATE:
                    return typeof(CurrentUserUpdateDiscordEvent);
                case Event.ENTITLEMENT_CREATE:
                    return typeof(EntitlementCreateDiscordEvent);
                case Event.THERMAL_STATE_UPDATE:
                    return typeof(ThermalStateUpdateDiscordEvent);
                case Event.ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE:
                    return typeof(ActivityInstanceParticipantsUpdateDiscordEvent);
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
            }
        }
        
        [CanBeNull]
        public static Event? GetEventFromType([NotNull] Type type)
        {
            if (type == typeof(ErrorDiscordEvent))
                return Event.ERROR;
            if (type == typeof(ReadyResponse))
                return Event.READY;
            if (type == typeof(VoiceStateUpdateDiscordEvent))
                return Event.VOICE_STATE_UPDATE;
            if (type == typeof(SpeakingStartDiscordEvent))
                return Event.SPEAKING_START;
            if (type == typeof(SpeakingStopDiscordEvent))
                return Event.SPEAKING_STOP;
            if (type == typeof(OrientationUpdateDiscordEvent))
                return Event.ORIENTATION_UPDATE;
            if (type == typeof(ActivityLayoutModeUpdateDiscordEvent))
                return Event.ACTIVITY_LAYOUT_MODE_UPDATE;
            if (type == typeof(CurrentUserUpdateDiscordEvent))
                return Event.CURRENT_USER_UPDATE;
            if (type == typeof(EntitlementCreateDiscordEvent))
                return Event.ENTITLEMENT_CREATE;
            if (type == typeof(ThermalStateUpdateDiscordEvent))
                return Event.THERMAL_STATE_UPDATE;
            if (type == typeof(ActivityInstanceParticipantsUpdateDiscordEvent))
                return Event.ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE;

            return null;
        }
    }
}