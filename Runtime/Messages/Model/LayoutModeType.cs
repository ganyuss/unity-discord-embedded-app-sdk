using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    public enum LayoutModeType
    {
        UNHANDLED = -1,
        FOCUSED = 0,
        PIP = 1,
        GRID = 2
    }
}