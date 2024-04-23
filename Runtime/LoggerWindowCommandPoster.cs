using DiscordActivitySdk.JavaScript;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

namespace DiscordActivitySdk
{
    /// <summary>
    /// Logs the commands to the console
    /// </summary>
    [PublicAPI]
    public class LoggerWindowCommandPoster : IWindowCommandPoster
    {
        private readonly ILogger Logger;

        public LoggerWindowCommandPoster() : this(Debug.unityLogger)
        {
        }
        
        public LoggerWindowCommandPoster([NotNull] ILogger logger)
        {
            Logger = logger;
        }

        public void PostCommand<TMessage, TResponse>(TMessage command) where TMessage : DiscordCommand<TResponse> where TResponse : DiscordEvent
        {
            Logger.Log(LogType.Log, "Window message posted:\n" + JsonConvert.SerializeObject(command, Formatting.Indented));
        }
    }
}