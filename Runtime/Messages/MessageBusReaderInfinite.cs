using System;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Events;
using UnityEngine;

namespace DiscordActivitySdk.Messages
{
    internal class MessageBusReaderInfinite<T> : QueueMessageBusReader<T> where T : DiscordEvent
    {
        protected override ILogger _logger { get; }
        protected override Func<T, Task> ReadDelegate { get; }
        public override bool ToBeRemoved => false;


        public MessageBusReaderInfinite(ILogger logger, Func<T, Task> readDelegate)
        {
            _logger = logger;
            ReadDelegate = readDelegate;
        }
    }
}