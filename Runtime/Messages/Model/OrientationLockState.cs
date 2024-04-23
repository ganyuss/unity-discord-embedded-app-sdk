using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    public enum OrientationLockState
    {
        UNHANDLED = -1,
        UNLOCKED = 1,
        PORTRAIT = 2,
        LANDSCAPE = 3,
    }
}