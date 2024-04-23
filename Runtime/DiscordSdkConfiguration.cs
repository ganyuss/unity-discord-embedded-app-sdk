using DiscordActivitySdk.JavaScript;
using JetBrains.Annotations;
using UnityEngine;

namespace DiscordActivitySdk
{
    /// <summary>
    /// Configuration for <see cref="DiscordSdk"/> objects. 
    /// </summary>
    [PublicAPI]
    public class DiscordSdkConfiguration
    {
        /// <summary>
        /// The client ID for OAuth authentication of your application. You can get it in the
        /// <a href="https://discord.com/developers/applications">Discord Developer Portal</a>.
        /// </summary>
        [NotNull]
        public string ClientId { get; }

        /// <summary>
        /// This value determines whether or not the <see cref="DiscordSdk"/> class will issue logs.
        /// Setting it to false will disable logging completely. 
        /// </summary>
        public bool EnableLogging { get; set; } = true;
        
        /// <summary>
        /// Setting this value will override the logger the <see cref="DiscordSdk"/> object will use.
        /// The default logger logs to the console directly.
        /// </summary>
        [CanBeNull]
        public ILogger OverrideLogger { get; set; }

        /// <summary>
        /// Setting this value will override the <see cref="IWindowMessageProvider"/> <see cref="DiscordSdk"/> will use.
        /// <br /><br />
        /// The default IWindowMessageProvider used is <see cref="WindowCommandBridge"/>.
        /// </summary>
        [CanBeNull]
        public IWindowMessageProvider OverrideWindowMessageProvider { get; set; }

        /// <summary>
        /// Setting this value will override the <see cref="IWindowCommandPoster"/> <see cref="DiscordSdk"/> will use.
        /// <br /><br />
        /// The default IWindowCommandPoster used is <see cref="WindowCommandBridge"/>.
        /// </summary>
        [CanBeNull]
        public IWindowCommandPoster OverrideWindowCommandPoster { get; set; }
        
        /// <summary>
        /// Setting this value will override the URI <see cref="DiscordSdk"/> will use.
        /// <br /><br />
        /// The SDK will read the <c>frame_id</c>, <c>instance_id</c>, <c>guild_id</c> and <c>channel_id</c>
        /// as query parameters from it.
        /// <br /><br />
        /// The default value is <see cref="Application.absoluteURL">Application.absoluteURL</see>.
        /// </summary>
        [CanBeNull]
        public string OverrideCurrentUri { get; set; }

        /// <summary>
        /// Creates an instance of the SDK configuration object.
        /// </summary>
        /// <param name="clientId">The client ID for OAuth authentication of your application. You can get it in the
        /// <a href="https://discord.com/developers/applications">Discord Developer Portal</a>.</param>
        public DiscordSdkConfiguration(string clientId)
        {
            ClientId = clientId;
        }
    }
}