using System;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;

namespace DiscordActivitySdk
{
    [PublicAPI]
    public interface IDiscordSdk
    {
        /// <summary>
        /// Return true if the <see cref="Initialize"/> flow has been completed, otherwise false. 
        /// </summary>
        public bool Initialized { get; }
        
        /// <summary>
        /// The provided client ID
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// The instance ID of the activity
        /// </summary>
        public string InstanceId { get; }
        /// <summary>
        /// The ID of the channel where the activity has been started in
        /// </summary>
        [CanBeNull] 
        public string ChannelId { get; }
        /// <summary>
        /// The ID of the Discord server where the activity has been started in
        /// </summary>
        [CanBeNull] 
        public string GuildId { get; }
        
        /// <summary>
        /// Initializes the SDK, hand shaking with the Discord application.
        /// <br /><br />
        /// Equivalent to the <a href="https://discord.com/developers/docs/developer-tools/embedded-app-sdk#ready">discordSDK.ready()</a>
        /// method of the native SDK
        /// </summary>
        /// <seealso cref="DiscordSdkUtility.InitializeAndAuthenticate"/>
        public Task Initialize();

        /// <summary>
        /// Listen for events from the Discord application. This method is for events that do not require
        /// extra information for the subscription (events extending from <see cref="ListenableNoParamDiscordEvent"/>).<br />
        /// for events that require extra arguments, see <see cref="AddEventListener{TEvent, TListenArgs}">AddEventListener(listener, args)</see>.
        /// <br /><br />
        /// you can add listeners for generic <see cref="DiscordEvent"/>s. However, for an event to be received by this
        /// SDK, it must subscribe to it. And the subscription process will only happen for non-generic listeners.
        /// <br /><br />
        /// For example, let's say one listen for <see cref="VoiceStateUpdateDiscordEvent"/>s and <see cref="CurrentUserUpdateDiscordEvent"/>s.
        /// If they also add a listener for <see cref="DiscordEvent"/>s, this listener will only receive
        /// VoiceStateUpdateDiscordEvents and CurrentUserUpdateDiscordEvents, as the SDK only subscribed to those ones.
        /// <br /><br />
        /// This method is equivalent to the <a href="https://discord.com/developers/docs/developer-tools/embedded-app-sdk#subscribe">discordSDK.subscribe()</a>
        /// method of the native SDK.
        /// </summary>
        /// <param name="listener">The listener that will consume the events.</param>
        /// <typeparam name="TEvent">The event type to subscribe to.</typeparam>
        public Task AddEventListener<TEvent>(Func<TEvent, Task> listener) where TEvent : ListenableNoParamDiscordEvent;

        /// <summary>
        /// Listen for events from the Discord application. This method is for events that require
        /// extra information for the subscription (events extending from <see cref="ListenableWithParamDiscordEvent{T}"/>).<br />
        /// for events that require extra arguments, see <see cref="AddEventListener{TEvent}">AddEventListener(listener)</see>.
        /// <br /><br />
        /// This method is equivalent to the <a href="https://discord.com/developers/docs/developer-tools/embedded-app-sdk#subscribe">discordSDK.subscribe()</a>
        /// method of the native SDK.
        /// </summary>
        /// <param name="listener">The listener that will consume the events.</param>
        /// <param name="args">The information required for subscription.</param>
        /// <typeparam name="TEvent">The event type to subscribe to.</typeparam>
        /// <typeparam name="TListenArgs">The type of the object holding the extra info.</typeparam>
        public Task AddEventListener<TEvent, TListenArgs>(Func<TEvent, Task> listener, TListenArgs args)
            where TEvent : ListenableWithParamDiscordEvent<TListenArgs>;

        /// <summary>
        /// Send a command to the Discord application.
        /// <br /><br />
        /// This method is equivalent to <a href="https://discord.com/developers/docs/developer-tools/embedded-app-sdk#sdk-commands">discordSDK.commands.[command]</a>.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command to send.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response.</typeparam>
        /// <returns></returns>
        public Task<TResponse> SendCommand<TCommand, TResponse>()
            where TCommand : DiscordCommand<TResponse>, new()
            where TResponse : DiscordEvent;

        /// <summary>
        /// Send a command to the Discord application.
        /// <br /><br />
        /// This method is equivalent to <a href="https://discord.com/developers/docs/developer-tools/embedded-app-sdk#sdk-commands">discordSDK.commands.[command]</a>.
        /// </summary>
        /// <param name="command">The command to send.</param>
        /// <typeparam name="TCommand">The type of the command to send.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response.</typeparam>
        public Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command)
            where TCommand : DiscordCommand<TResponse> where TResponse : DiscordEvent;

        public void Close(RPCCloseCodes code, string message);
    }
}
