using System;
using System.Collections.Generic;
using DiscordActivitySdk.JavaScript;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DiscordActivitySdk.Messages
{
    public class DiscordMessageBus
    {
        private readonly IWindowMessageProvider _messageProvider;
        private readonly ILogger _logger;

        private readonly HashSet<IMessageBusReader> ReaderSet = new HashSet<IMessageBusReader>();

        private readonly object EventAndReaderLock = new object();
        
        public DiscordMessageBus(IWindowMessageProvider messageProvider, ILogger logger)
        {
            _messageProvider = messageProvider;
            _logger = logger;
        }

        public void Start()
        {
            _messageProvider.EventReceived += ConsumeMessage;
            _messageProvider.StartProviding();
        }

        public void Stop()
        {
            _messageProvider.StopProviding();
            _messageProvider.EventReceived -= ConsumeMessage;
        }

        public void AddReader([NotNull] IMessageBusReader reader)
        {
            lock (EventAndReaderLock)
            {
                ReaderSet.Add(reader);
            }
        }
        
        private void ConsumeMessage(WindowMessage message)
        {
            // The allowed origin test is done on the JS level

            if (message.Data.Type != JTokenType.Array)
                return;
            
            object data = message.Data[1];
            
            HandleFrame(data);
            
            /*
             We don't switch, instead we put all the values in the bus for DiscordSdk class
             to read
            switch (opCode) {
                case OpCode.HELLO:
                    break;
                case OpCode.CLOSE:
                    HandleClose(data);
                    break;
                case OpCode.HANDSHAKE:
                    HandleHandshake();
                    break;
                case OpCode.FRAME:
                    HandleFrame(data);
                    break;
            }
            */
        }

        private void HandleFrame(object data)
        {
            try
            {
                if (!(data is JObject jObject))
                    return;

                var baseDiscordEvent = jObject.ToObject<DiscordEvent>();

                if (!TryGetEventClassType(baseDiscordEvent, out var eventClassType)) 
                    return;

                var discordEvent = jObject.ToObject(eventClassType);

                if (discordEvent is not DiscordEvent typedDiscordEvent)
                    return;
                
                RegisterNewEvent(typedDiscordEvent);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
            }
        }

        private static bool TryGetEventClassType(DiscordEvent baseDiscordEvent, out Type eventClassType)
        {
            var eventType = baseDiscordEvent.EventType;
            if (eventType != null)
            {
                eventClassType = eventType.Value.GetAssociatedClassType();
                return true;
            }
            
            if (baseDiscordEvent.Command != null
                && baseDiscordEvent.Nonce != null
                && Enum.TryParse<Command>(baseDiscordEvent.Command, out var enumCommand))
            {
                eventClassType = enumCommand.GetAssociatedResponseType();
                return true;
            }

            Debug.LogError($"Cannot find event type for object {baseDiscordEvent}");
            eventClassType = null;
            return false;
        }

        private void RegisterNewEvent(DiscordEvent discordEvent)
        {
            lock (EventAndReaderLock)
            {
                RemoveReadersToBeRemoved();
            
                foreach (var reader in ReaderSet) 
                    reader.AddEventToRead(discordEvent);
            }
        }

        private void RemoveReadersToBeRemoved()
        {
            ReaderSet.RemoveWhere(reader => reader.ToBeRemoved);
        }
    }
}