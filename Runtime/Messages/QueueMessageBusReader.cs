using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace DiscordActivitySdk.Messages
{
    public abstract class QueueMessageBusReader<T> : IMessageBusReader where T : DiscordEvent
    {
        [CanBeNull] 
        protected abstract ILogger _logger { get; }
        [NotNull] 
        protected abstract Func<T, Task> ReadDelegate { get; }
        
        private readonly ConcurrentQueue<DiscordEvent> EventsInQueue = new ConcurrentQueue<DiscordEvent>();
        

        public abstract bool ToBeRemoved { get; }
        private bool IsReading;
        
        private async void ReadAllInQueue()
        {
            try
            {
                IsReading = true;

                while (EventsInQueue.Count > 0 
                       && !ToBeRemoved
                       && EventsInQueue.TryDequeue(out var discordEvent))
                {
                    if (discordEvent is not T typedDiscordEvent) 
                        continue;
                    
                    try
                    {
                        await ReadDelegate.Invoke(typedDiscordEvent);
                    }
                    catch (Exception e)
                    {
                        _logger?.LogError("", "Error when reading message bus");
                        _logger?.LogException(e);
                    }
                }
            }
            catch (Exception e)
            {
                _logger?.LogError("", "Error when reading message bus");
                _logger?.LogException(e);
            }
            finally
            {
                IsReading = false;
            }
        }

        public void AddEventToRead(DiscordEvent discordEvent)
        {
            EventsInQueue.Enqueue(discordEvent);
            
            if (! IsReading && ! ToBeRemoved)
                ReadAllInQueue();
        }
    }
}