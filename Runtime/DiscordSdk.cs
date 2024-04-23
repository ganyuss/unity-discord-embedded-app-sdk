using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscordActivitySdk.JavaScript;
using DiscordActivitySdk.Messages;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;
using UnityEngine;
using Event = DiscordActivitySdk.Messages.Events.Event;

namespace DiscordActivitySdk
{
    /// <summary>
    /// The entry point of the SDK. Use it to interact with the Discord application that embed your activity.
    /// </summary>
    [PublicAPI]
    public class DiscordSdk : IDiscordSdk
    {
        public bool Initialized { get; private set; }
        private bool Initializing { get; set; }
        
        public string ClientId { get; }
        public string InstanceId { get; private set; }
        public string ChannelId { get; private set; }
        public string GuildId { get; private set; }

        private string FrameId { get; set; }
        
        private Task InitializationTask;

        [NotNull] private readonly DiscordMessageBus DiscordMessageBus;
        [NotNull] private readonly IWindowMessageProvider MessageProvider;
        [NotNull] private readonly IWindowCommandPoster CommandPoster;
        [NotNull] private readonly Uri CurrentUri;
        [CanBeNull] private readonly LoggerWrapper Logger;

        [NotNull] private readonly Dictionary<Event, int> UserEventListenerCount = new Dictionary<Event, int>();
        
        
        public DiscordSdk([NotNull] DiscordSdkConfiguration configuration)
        {
            ClientId = configuration.ClientId;
            MessageProvider = configuration.OverrideWindowMessageProvider ?? WindowCommandBridge.Instance;
            CommandPoster = configuration.OverrideWindowCommandPoster ?? WindowCommandBridge.Instance;
            CurrentUri = new Uri(configuration.OverrideCurrentUri ?? Application.absoluteURL);
            
            if (configuration.EnableLogging)
                Logger = new LoggerWrapper(configuration.OverrideLogger ?? Debug.unityLogger);
            
            DiscordMessageBus = new DiscordMessageBus(MessageProvider, Logger);
            
            if (! configuration.EnableLogging && configuration.OverrideLogger != null)
                new LoggerWrapper(Debug.unityLogger)
                    .Log(LogType.Warning, "from the configuration, EnableLogging is set to false, but OverrideLogger is set. " +
                                          "This may be a mistake.");
        }

        public async Task Initialize()
        {
            if (InitializationTask == null) 
                InitializationTask = DoInitialize();

            await InitializationTask;
        }

        private async Task DoInitialize()
        {
            Initializing = true;
            Logger?.Log("Starting initialising...");
            
            ReadUriValues();
            DiscordMessageBus.Start();
            
            await SendCommand<HandshakeDiscordCommand, ReadyResponse>(new HandshakeDiscordCommand(
                version: 1,
                ClientId,
                FrameId
            ));

            Initialized = true;
            Initializing = false;
            
            Logger?.Log("Initialisation complete!");
        }

        private void ReadUriValues()
        {
            var query = ReadUriQuery(CurrentUri);

            if (! query.TryGetValue("frame_id", out var frameId))
                throw new ArgumentException("frame_id query param is not defined");
            FrameId = frameId;

            if (! query.TryGetValue("instance_id", out var instanceId))
                throw new ArgumentException("instance_id query param is not defined");
            InstanceId = instanceId;

            if (query.TryGetValue("guild_id", out var guildId))
                GuildId = guildId;
            
            if (query.TryGetValue("channel_id", out var channelId))
                ChannelId = channelId;
        }

        private static Dictionary<string, string> ReadUriQuery(Uri uri)
        {
            return uri.Query
                .TrimStart('?')
                .Split('&')
                .Select(queryElement => queryElement.Split('='))
                .ToDictionary(data => data[0], data => data[1]);
        }

        public void Close(RPCCloseCodes code, string message)
        {
            DiscordMessageBus.Stop();
            
            var closeCommand = new CloseDiscordCommand(code, message);
            CommandPoster.PostCommand<CloseDiscordCommand, EmptyResponse>(closeCommand);
        }

        public async Task AddEventListener<TEvent>(Func<TEvent, Task> listener) where TEvent : ListenableNoParamDiscordEvent
        {
            await DoAddEventListener(listener, null);
        }
        
        public async Task AddEventListener<TEvent, TListenArgs>(Func<TEvent, Task> listener, TListenArgs args)
            where TEvent : ListenableWithParamDiscordEvent<TListenArgs>
        {
            await DoAddEventListener(listener, args);
        }
        
        private async Task DoAddEventListener<TEvent>(Func<TEvent, Task> listener, object args) 
            where TEvent : DiscordEvent
        {
            var nullableEventEnumValue = EventTypeUtility.GetEventFromType(typeof(TEvent));
            
            DiscordMessageBus.AddReader(new MessageBusReaderInfinite<TEvent>(
                Logger,
                listener
            ));

            if (nullableEventEnumValue == null)
                return;

            var eventEnumValue = nullableEventEnumValue.Value;
            if (UserEventListenerCount.TryGetValue(eventEnumValue, out var count))
                UserEventListenerCount[eventEnumValue] = count + 1;
            else
                UserEventListenerCount[eventEnumValue] = 1;

            if (UserEventListenerCount[eventEnumValue] == 1)
            {
                await SendCommand<SubscribeDiscordCommand, SubscribeResponse>(
                    new SubscribeDiscordCommand(eventEnumValue)
                    {
                        Args = args
                    });
            }
        }
        
        public async Task<TResponse> SendCommand<TCommand, TResponse>() where TCommand : DiscordCommand<TResponse>, new()
            where TResponse : DiscordEvent
            => await SendCommand<TCommand, TResponse>(new TCommand());
        
        public async Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command) where TCommand : DiscordCommand<TResponse> where TResponse : DiscordEvent
        {
            var taskSource = new TaskCompletionSource<TResponse>();

            var commandId = command.Guid;
            DiscordMessageBus.AddReader(
                new MessageBusReaderOnce<DiscordEvent>(
                    Logger,
                    discordEvent =>
                    {
                        if (commandId != null && discordEvent.Nonce != commandId.ToString())
                        {
                            return Task.FromResult(false);
                        }
                        
                        if (discordEvent is ErrorDiscordEvent error)
                            taskSource.SetException(error.ToException());
                        else if (discordEvent is TResponse response)
                            taskSource.SetResult(response);
                            
                        return Task.FromResult(true);
                    }));
            
            Logger?.Log($"Sending {command.GetType().Name} message");
            CommandPoster.PostCommand<TCommand, TResponse>(command);

            var response = await taskSource.Task;
            Logger?.Log($"Received {response.GetType().Name} response");
            
            return response;
        }
    }
}
