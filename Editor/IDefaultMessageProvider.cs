using System;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;

namespace DiscordActivitySdk.Editor
{
    /// <summary>
    /// Implementors of this interface can be used in <see cref="EditorMessageProvider"/> to pre-fill
    /// message data in the editor window. 
    /// </summary>
    [PublicAPI]
    public interface IDefaultMessageProvider
    {
        /// <summary>
        /// Returns the default values for the given event type. If null is returned, an empty
        /// default event will be used. <br /><br />
        /// Make sure to return the requested type instance!
        /// </summary>
        /// <param name="discordEventType">The type of event to return.</param>
        /// <returns>An event with with default values to use in the editor window, or null for
        /// no default values.</returns>
        [CanBeNull] 
        public DiscordEvent GetDefaultMessageFor([NotNull] Type discordEventType);
    }
}