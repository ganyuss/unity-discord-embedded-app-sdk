using System;
using DiscordActivitySdk.Editor.UI;
using DiscordActivitySdk.JavaScript;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DiscordActivitySdk.Editor
{
    /// <summary>
    /// Let you send messages to the <see cref="DiscordSdk"/> instance using
    /// an editor window. 
    /// </summary>
    [PublicAPI]
    public class EditorMessageProvider : IWindowMessageProvider
    {
        public event Action<WindowMessage> EventReceived;

        private bool Providing;
        private EditorMessageWindow Window;

        private readonly IDefaultMessageProvider DefaultMessageProvider;

        /// <summary>
        /// Default constructor, will use <see cref="SampleDefaultMessageProvider"/> as default message
        /// provider.
        /// </summary>
        public EditorMessageProvider()
            : this(new SampleDefaultMessageProvider())
        {
        }
        
        
        public EditorMessageProvider(IDefaultMessageProvider defaultMessageProvider)
        {
            DefaultMessageProvider = defaultMessageProvider;
        }
        
        public void StartProviding()
        {
            if (!Window)
                Window = EditorMessageWindow.AttachNewWindowTo(this, DefaultMessageProvider);
            
            Providing = true;
        }

        public void StopProviding()
        {
            Providing = false;
        }

        public void SendEventFromEditorWindow(DiscordEvent discordEvent)
        {
            if (Providing)
            {
                SendEventAsWindowMessage(discordEvent);
            }
            else
            {
                Debug.LogError("Cannot send discord event because the provider is not activated.");
            }
        }

        private void SendEventAsWindowMessage(DiscordEvent discordEvent)
        {
            var serializedEvent = JsonConvert.SerializeObject(discordEvent);
            var deserializedEvent = JsonConvert.DeserializeObject(serializedEvent);

            var message = new WindowMessage
            {
                Data = JToken.FromObject(new[]
                {
                    OpCode.FRAME,
                    deserializedEvent
                })
            };

            EventReceived?.Invoke(message);
        }
    }
}