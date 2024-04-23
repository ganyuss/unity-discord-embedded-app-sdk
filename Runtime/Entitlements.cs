using JetBrains.Annotations;

namespace DiscordActivitySdk
{
    /// <summary>
    /// This class defines the entitlements required for the available commands/messages. 
    /// </summary>
    [PublicAPI]
    public static class Entitlements
    {
        public static string Identify => "identify";
        public static string RpcVoiceRead => "rpc.voice.read";
        public static string RpcActivitiesWrite => "rpc.activities.write";
        public static string Guilds => "guilds";
        public static string DmChannelsRead => "dm_channels.read";
        public static string GuildsMemberRead => "guilds.members.read";
    }
}
