using System;
using System.Threading.Tasks;
using DiscordActivitySdk.Messages.Commands;
using DiscordActivitySdk.Messages.Events.Responses;
using JetBrains.Annotations;

namespace DiscordActivitySdk
{
    /// <summary>
    /// Implements helper functions for the <see cref="DiscordSdk"/> class.
    /// </summary>
    [PublicAPI]
    public static class DiscordSdkUtility
    {
        /// <summary>
        /// This utility method encapsulate the whole initialization process required to use the Discord SDK.
        /// <br /><br />
        /// This method is equivalent to the initialization process explained <a href="https://discord.com/developers/docs/activities/building-an-activity#step-5-authorizing-authenticating-users">here</a>.
        /// </summary>
        /// <param name="discordSdk">The DiscordSDK instance to initialize.</param>
        /// <param name="authorizeDiscordCommand">The authorize command to send during the flow.</param>
        /// <param name="authorizeCodeToAccessToken">A delegate that will take the authorization code, and return an OAuth
        /// access token from Discord's servers. See the readme for more info.</param>
        /// <returns></returns>
        [NotNull, ItemNotNull]
        public static async Task<AuthenticateResponseData> InitializeAndAuthenticate(
            [NotNull] this IDiscordSdk discordSdk, 
            [NotNull] AuthorizeDiscordCommand authorizeDiscordCommand,
            [NotNull] Func<string, Task<string>> authorizeCodeToAccessToken)
        {
            await discordSdk.Initialize();

            var authorizeResponse = await discordSdk.SendCommand<AuthorizeDiscordCommand, AuthorizeResponse>(authorizeDiscordCommand);
            
            var accessToken = await authorizeCodeToAccessToken.Invoke(authorizeResponse.Data.Code);
            
            var authenticateResponse = await discordSdk.SendCommand<AuthenticateDiscordCommand, AuthenticateResponse>(new AuthenticateDiscordCommand(accessToken));
            return authenticateResponse.Data;
        }
    }
}