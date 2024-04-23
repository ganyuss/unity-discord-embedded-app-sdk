using System;
using System.Runtime.InteropServices;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.JavaScript
{
    [PublicAPI]
    public class WindowCommandBridge : MonoBehaviour, IWindowMessageProvider, IWindowCommandPoster
    {
        private static WindowCommandBridge _instance;
        
        [NotNull]
        public static WindowCommandBridge Instance
        {
            get
            {
                _instance ??= CreateInstance();
                return _instance;
            }
        }

        [NotNull]
        private static WindowCommandBridge CreateInstance()
        {
            // Must be the same name as in discord bridge plugin 
            var gameObject = new GameObject("Discord JS window message listener");
            var newInstance = gameObject.AddComponent<WindowCommandBridge>();
            
            DontDestroyOnLoad(gameObject);
            return newInstance;
        }
        
        [DllImport("__Internal")]
        private static extern void InitializeDiscordBridge();
        
        [DllImport("__Internal")]
        private static extern void StartListeningToWindowMessages();
        
        [DllImport("__Internal")]
        private static extern void StopListeningToWindowMessages();
        
        [DllImport("__Internal")]
        private static extern void SendMessageToSource(string stringMessage);


        private bool IsNonEditorWebGL => Application.platform == RuntimePlatform.WebGLPlayer
                                         && !Application.isEditor;

        private static bool NativeInitialized = false;

        public event Action<WindowMessage> EventReceived;

        void IWindowMessageProvider.StartProviding()
            => Connect();
        
        void IWindowMessageProvider.StopProviding()
            => Disconnect();
        
        public void Connect()
        {
            if (!NativeInitialized)
            {
                if (IsNonEditorWebGL) InitializeDiscordBridge();
                NativeInitialized = true;
            }
            
            
            if (IsNonEditorWebGL) StartListeningToWindowMessages();
        }
        
        public void Disconnect()
        {
            if (IsNonEditorWebGL) StopListeningToWindowMessages();
        }

        [Preserve]
        [UsedImplicitly] // Called by JS
        private void ReceiveMessage([NotNull] string jsonPayload)
        {
            try
            {
                var message = JsonConvert.DeserializeObject<WindowMessage>(jsonPayload);
                
                if (message != null)
                    EventReceived?.Invoke(message);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void PostCommand<TCommand, TResponse>(TCommand command) 
            where TCommand : DiscordCommand<TResponse>
            where TResponse : DiscordEvent
        {
            object messageData;

            if (command is FrameDiscordCommand<TResponse> frameCommand)
                messageData = SerializableFrameCommand.ToSerializable(frameCommand);
            else
                messageData = command;
            
            string stringMessage = JsonConvert.SerializeObject(new object[]
            {
                command.OpCode,
                messageData
            });
            
            if (IsNonEditorWebGL) SendMessageToSource(stringMessage);
        }
    }
}