using System;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.JavaScript
{
    internal class SerializableFrameCommand
    {
        public static SerializableFrameCommand ToSerializable<T>(FrameDiscordCommand<T> originalCommand) where T : DiscordEvent
        {
            return new SerializableFrameCommand(originalCommand.Command, originalCommand.Guid!.Value, originalCommand);
        }

        private SerializableFrameCommand(Command command, Guid guid, object payload)
        {
            Command = command;
            Guid = guid;
            Payload = payload;
        }
        
        [JsonProperty("cmd")]
        public Command Command { [Preserve] get; }
        
        [JsonProperty("nonce")]
        public Guid Guid { [Preserve] get; }
        
        [JsonProperty("args")]
        public object Payload { [Preserve] get; }
    }
}