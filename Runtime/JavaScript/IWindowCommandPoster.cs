using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;

namespace DiscordActivitySdk.JavaScript
{
    /// <summary>
    /// Implementers of this interface are used by <see cref="DiscordSdk"/> to send commands to the Discord application.  
    /// </summary>
    public interface IWindowCommandPoster
    {
        /// <summary>
        /// Posts a command to the Discord app
        /// </summary>
        /// <param name="command">The command to post</param>
        /// <typeparam name="TCommand">The type of the command</typeparam>
        /// <typeparam name="TResponse">The type of the response of the given command</typeparam>
        public void PostCommand<TCommand, TResponse>([NotNull] TCommand command)
            where TCommand : DiscordCommand<TResponse>
            where TResponse : DiscordEvent;
    }
}