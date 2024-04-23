using System;
using DiscordActivitySdk.Messages.Events;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

namespace DiscordActivitySdk.Editor
{
    internal class SampleDefaultMessageProvider : IDefaultMessageProvider
    {
        private static readonly User DefaultUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = "DefaultUser" + Random.Range(100, 1000),
            Discriminator = Random.Range(0, 1000).ToString(),
            
            GlobalName = null,
            Avatar = "https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0a6a49cf127bf92de1e2_icon_clyde_blurple_RGB.png",
            AvatarDecoration = new AvatarDecoration
            {
                Asset = "abcdefg",
                SkuId = "123456789"
            },
            
            IsBot = false,
            Flags = 1,
            PremiumType = null
        };
        
        private static readonly DiscordEvent[] DefaultMessages = new DiscordEvent[]
        {
            new ReadyResponse
            {
                Data = new ReadyResponseData {
                    User = DefaultUser,
                    Version = 1,
                    Config = new ReadyConfig
                    {
                        ApiEndpoint = "//discord.com/api",
                        Environment = "production",
                        CdnHost = "cdn.discordapp.com"
                    }
                }
            }
        };
        
        public DiscordEvent GetDefaultMessageFor(Type discordEventType)
        {
            foreach (var defaultMessage in DefaultMessages)
            {
                if (defaultMessage.GetType() == discordEventType)
                    return defaultMessage;
            }

            return null;
        }
    }
}