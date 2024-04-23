using System;
using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [Flags]
    [PublicAPI]
    public enum Permission : long
    {
        // Note: BigFlagUtils.getFlag(x) => 1 << x
        CREATE_INSTANT_INVITE = 1 << 0,
        ADMINISTRATOR = 1 << 3,
        
    }
}