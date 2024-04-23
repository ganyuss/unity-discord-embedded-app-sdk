using System;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace DiscordActivitySdk.Messages
{
    public class MessageBusReaderOnce<T> : QueueMessageBusReader<T> where T : DiscordEvent
    {
        protected override ILogger _logger { get; }
        protected override Func<T, Task> ReadDelegate { get; }
        public override bool ToBeRemoved => _toBeRemoved;
        
        private bool _toBeRemoved;


        public MessageBusReaderOnce([CanBeNull] ILogger logger, Func<T, Task> readDelegate)
        {
            _logger = logger;
            ReadDelegate = async ev =>
            {
                await readDelegate.Invoke(ev);
                _toBeRemoved = true;
            };
        }
        
        public MessageBusReaderOnce([CanBeNull] ILogger logger, Func<T, Task<bool>> readDelegate)
        {
            _logger = logger;
            ReadDelegate = async ev =>
            {
                _toBeRemoved = await readDelegate.Invoke(ev);
            };
        }
    }
}