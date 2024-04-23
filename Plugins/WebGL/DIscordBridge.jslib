
mergeInto(LibraryManager.library, {
  
	InitializeDiscordBridge: function () {
		this.unityDiscordActivity = {
			source: window.parent.opener != null ? window.parent.opener : window.parent,
			sourceOrigin: !!document.referrer ? document.referrer : '*',
		
			windowMessageHandler: function (message) {
			
				const ALLOWED_ORIGINS = new Set([
					window.location.origin,
					'https://discord.com',
					'https://discordapp.com',
					'https://ptb.discord.com',
					'https://ptb.discordapp.com',
					'https://canary.discord.com',
					'https://canary.discordapp.com',
					'https://staging.discord.co',
					'http://localhost:3333',
					'https://pax.discord.com',
					'null'
				]);
			
				if (!ALLOWED_ORIGINS.has(message.origin)) return;
				
				
				// We need to flatten the message, otherwise JSON.stringify won't take the parent's properties in account
				var flattenedMessage = {};   
				for(var key in message) {
					if (!(message[key] instanceof Window) // JSON.stringify cannot serialise Window objects, because they have DOM references
						&& key !== "source" // For some reason the source object is not instance of Window. Maybe because it is restricted?
						&& typeof message[key] !== "function") {
						flattenedMessage[key] = message[key];   
					}
				}   
				
				var messageString = JSON.stringify(flattenedMessage, (key, value) =>
                    typeof value === 'bigint'
                        ? value.toString()
                        : value // return everything else unchanged
                );
				
				SendMessage('Discord JS window message listener', 'ReceiveMessage', messageString);
			},
		};
	},
	
	StartListeningToWindowMessages: function () {
		window.addEventListener('message', this.unityDiscordActivity.windowMessageHandler);
		
		console.log("[UnityDiscordSDK] Started listening to window messages");
	},
  
	StopListeningToWindowMessages: function () {
		window.removeEventListener('message', this.unityDiscordActivity.windowMessageHandler);
		
		console.log("[UnityDiscordSDK] Stopped listening to window messages");
	},
	
	SendMessageToSource: function (stringMessagePtr) {
	
		var stringMessage = UTF8ToString(stringMessagePtr);
		var message = JSON.parse(stringMessage);
		
		this.unityDiscordActivity.source.postMessage(
			message,
			this.unityDiscordActivity.sourceOrigin
		);
	}
});