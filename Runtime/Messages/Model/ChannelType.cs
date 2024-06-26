﻿using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    public enum ChannelType
    {
        UNHANDLED = -1,
        GUILD_TEXT = 0,
        DM = 1,
        GUILD_VOICE = 2,
        GROUP_DM = 3,
        GUILD_CATEGORY = 4,
        GUILD_ANNOUNCEMENT = 5,
        GUILD_STORE = 6,
        ANNOUNCEMENT_THREAD = 10,
        PUBLIC_THREAD = 11,
        PRIVATE_THREAD = 12,
        GUILD_STAGE_VOICE = 13,
        GUILD_DIRECTORY = 14,
        GUILD_FORUM = 15,
    }
}