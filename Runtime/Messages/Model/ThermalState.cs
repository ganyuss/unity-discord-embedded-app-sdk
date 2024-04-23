using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    public enum ThermalState
    {
        UNHANDLED = -1,
        NOMINAL = 0,
        FAIR = 1,
        SERIOUS = 2,
        CRITICAL = 3
    }
}