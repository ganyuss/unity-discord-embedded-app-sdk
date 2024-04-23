using DiscordActivitySdk.Messages.Events;

namespace DiscordActivitySdk
{
    /// <summary>
    /// Operation codes as defined by the discord application. It is used to identify <see cref="DiscordEvent"/> context.
    /// </summary>
    public enum OpCode {
        /// <summary>
        /// Initialization operation
        /// </summary>
        HANDSHAKE = 0,
        /// <summary>
        /// Regular event operation
        /// </summary>
        FRAME = 1,
        /// <summary>
        /// Closing operation
        /// </summary>
        CLOSE = 2,
        /// <summary>
        /// Deprecated
        /// </summary>
        HELLO = 3,
    }
}