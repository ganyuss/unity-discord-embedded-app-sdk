using System;

namespace DiscordActivitySdk.JavaScript
{
    /// <summary>
    /// Implementers of this interface provide input messages from the Discord app to <see cref="DiscordSdk"/>.
    /// </summary>
    public interface IWindowMessageProvider
    {
        /// <summary>
        /// Event invoked whenever a message is received
        /// </summary>
        public event Action<WindowMessage> EventReceived;

        /// <summary>
        /// Activates the window message provider. It will start providing the received messages
        /// through <see cref="EventReceived"/>.
        /// </summary>
        public void StartProviding();
        /// <summary>
        /// Deactivates the window message provider. 
        /// </summary>
        public void StopProviding();
    }
}