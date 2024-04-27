# Discord Activity SDK
The Discord Activity SDK package lets you create custom Discord Activities 
with Unity. Using it, you will be able to send command to the discord client, 
as well as listening for events.

This package is meant to work in Unity WebGL builds, and only work on 
the client side of the Discord activity.

> ⛔ This is **not** a package to implement discord's rich presence feature.

> ⚠️ Just like Discord's [embedded app SDK package](https://github.com/discord/embedded-app-sdk), this
> package only serves for the frontend part of the Discord activity, to interact with the Discord application.
> On top of that, you will need to setup a HTTP server to serve this WebGL build, and game server(s) for
> your multiplayer game to work.

## Context

This package is a Unity implementation of Discord's [embedded app SDK package](https://github.com/discord/embedded-app-sdk).
It implements all its features and more. This implementation is based on
the version 1.2.1 of the native SDK.

If you are familiar with this SDK, you can skip directly to the [Differences and Additions](#differences-and-additions)
section.

## Installing the SDK

To install the SDK, clone the content of this repository into a folder in the 
`Packages` folder of your project.

## Getting started

> 🩵 This section is equivalent to the [Building Your First Activity in Discord](https://discord.com/developers/docs/activities/building-an-activity) 
> section of the native SDK documentation.

### 1. Creating and configuring you Discord application

To setup your discord application, follow The [step 1](https://discord.com/developers/docs/activities/building-an-activity#step-1-creating-a-new-app) 
and [step 2](https://discord.com/developers/docs/activities/building-an-activity#configure-your-activity) 
of the "Building your first activity" document.

### 2. Create a HTTP server that serves your WebGL build

This is outside the scope of this documentation, but you will have to setup a HTTP server to serve your WebGL build to
the player that will try to start your application. For your testing phase, you can
serve your app using a local HTTP server, as described in [this documentation step](https://discord.com/developers/docs/activities/building-an-activity#step-4-running-your-app-locally-in-discord).

### 3. Initialise the SDK

To initialise the Discord SDK, you will first need to create a [`DiscordSdk`](Runtime/DiscordSdk.cs) instance.
Here is an example:

```csharp
// !!! CODE TO COMPLETE !!! 
// You can find your client ID in the Discord developer portal: https://discord.com/developers/applications 
var discordConfig = new DiscordSdkConfiguration(**YOUR DISCORD CLIENT ID**);

// For the discord SDK to work correctly in editor, you will have to override some values
#if UNITY_EDITOR
// We need to provide a fake URI with a frame_id and an instance_id, otherwise initialization will throw an exception
discordConfig.OverrideCurrentUri = "http://www.example.com/test?frame_id=editor_frame_id&instance_id=editor_instance_id";
// This override will let you send messages to the SDK using an editor window
discordConfig.OverrideWindowMessageProvider = new EditorMessageProvider();
// This override will redirect the messages from the SDK to the console for you to read
config.OverrideWindowCommandPoster = new LoggerWindowCommandPoster();
#endif

var discordSdk = new DiscordSdk(discordConfig);
```

Once we have the instance, we need to initialise it. As you can see in [this
section](https://discord.com/developers/docs/activities/building-an-activity#calling-your-backend-server-from-your-client)
of the native SDK's documentation, the initialisation process is lengthy. 
It basically boils down to 3 steps:
* Executing an Authorize command
* Using the code returned by that command to get an access token from Discord OAuth API
* Return that access token to the Discord client through an Authenticate command

The second step is tricky. In order to get the access token, you need to do a POST
request containing your app's client secret. You __must__ not put this secret in your
app's client code, or your app will be at risk. Instead, your client must send 
a request to your server, and your server must query Discord's.

You can see how it is done in Discord's example [here](https://github.com/discord/embedded-app-sdk/blob/main/examples/discord-activity-starter/packages/server/src/app.ts).

On the client side, there is a helper method to initialise the SDK. You can implement it by completing this code:
```csharp
var authorizeCommand = new AuthorizeDiscordCommand(
    // !!! CODE TO COMPLETE !!! 
    clientId: **YOUR DISCORD CLIENT ID**,
    AuthorizeResponseType.Code,
    scopes: new[]
    {
        // You should put here all the entitlements your app requires
        Entitlements.Identify,
        Entitlements.Guilds,
        Entitlements.RpcActivitiesWrite,
        Entitlements.RpcVoiceRead,
        Entitlements.GuildsMemberRead
    });

// This delegate should hold your code requesting your backend to get the access token
Func<string, Task<string>> authorizeCodeToAccessToken = async (authorizeCode) =>
{
    var applicationUri = new Uri(Application.absoluteURL);
    
    // !!! CODE TO COMPLETE !!! 
    var requestTarget = $"https://{applicationUri.Authority}/**YOUR TOKEN ENDPOINT**?code={authorizeCode}";

    var request = UnityWebRequest.Get(requestTarget);
    await request.SendWebRequest();

    
    // !!! CODE TO COMPLETE !!! 
    // You need to get the access token from your backend's response (request.downloadHandler.text)
    return accessToken;
};

await discordSdk.InitializeAndAuthenticate(authorizeCommand, authorizeCodeToAccessToken);
```

And with that, your app is authenticated! You can now interact with the Discord
application.

### 4. Interacting with the Discord application

There are 2 main ways of interacting with the Discord application: listening
to events, and sending commands.

To listen for an event type, use `DiscordSdk.AddEventListener`. You can 
remove your listener using `DiscordSdk.RemoveEventListener`. You will
find the list of all available events [here](https://discord.com/developers/docs/developer-tools/embedded-app-sdk#sdk-events).

To send a command, use `DiscordSdk.SendCommand`. You can omit the parameter
if the command does not require any information. You can find the list of all
available commands [here](https://discord.com/developers/docs/developer-tools/embedded-app-sdk#sdk-commands).

Examples:
```csharp
await discordSdk.AddEventListener<VoiceStateUpdateDiscordEvent, VoiceStateParameters>(evt =>
    {
        Debug.LogError(evt.Data.User.Username + " voice state update");
        return Task.CompletedTask;
    }, 
    new VoiceStateParameters(discordSdk.ChannelId!));

await discordSdk.AddEventListener<ActivityInstanceParticipantsUpdateDiscordEvent>(evt =>
    {
        Debug.LogError("New participants count : " + evt.Data.Participants.Length);
        return Task.CompletedTask;
    });
```

```csharp
var localeData = await discordSdk.SendCommand<UserSettingsGetLocaleDiscordCommand, UserSettingsGetLocaleResponse>();
Debug.LogError(localeData.Data.Locale);

var acvitityData = await discordSdk.SendCommand<SetActivityDiscordCommand, SetActivityResponse>(new SetActivityDiscordCommand(new ActivityUpdate
    {
        Details = "My superb activity",
        Instance = true
    }));
```

## Differences and Additions

This section regroups the differences between the native Discord embedded app SDK
and this SDK.

### 1. Naming

Most of the names have bee tweaked to match C# conventions:
1. Enum names have been changed to be singular
2. class, property and method names names have been changed to be in UpperCamelCase

`DiscordSdk.ready()` method from the native SDK has been renamed
to `DiscordSdk.Initialize()`.

commands and events are also represented by classes instead of enums. 
The class names are the enum values in UpperCamelCase, followed by
`DiscordCommand` or `DiscordEvent` respectively. 

### 2. Utility

A couple of quality of life additions have been implemented in this SDK:

* There is an extension method for `DiscordSdk` to streamline initialisation, 
called `InitializeAndAuthenticate`.

* You can change the objects responsible for providing/sending messages from/to
the Discord application. This is useful to run tests in editor (see [Initialise the SDK](#3-initialise-the-sdk)).

* The SDK does not automatically redirect the app's logs (see [overrideConsoleLogging](https://github.com/discord/embedded-app-sdk/blob/4ecb602c65b8c4e7a6e618aaf76b303ccde04aa4/src/Discord.ts#L220)).