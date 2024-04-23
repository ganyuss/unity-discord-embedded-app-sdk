using System;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace DiscordActivitySdk.Messages
{
    public class UserMessageBusReader<T> : QueueMessageBusReader<T> where T : DiscordEvent
    {
        protected override ILogger _logger { get; }
        protected override Func<T, Task> ReadDelegate { get; }
        public override bool ToBeRemoved => ListenerRemoved;

        public bool ListenerRemoved { get; set; }

        public UserMessageBusReader([CanBeNull] ILogger logger, [NotNull] Func<T, Task> readDelegate)
        {
            ReadDelegate = readDelegate;
            _logger = logger;
        }
    }
}