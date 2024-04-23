using System;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Returns information about the channel for a provided channel ID.
    /// <br /><br />
    /// <b>Supported Platforms</b>
    /// <list type="table">
    ///     <item>
    ///         <term>Web</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>iOS</term>
    ///         <description>✅</description>
    ///     </item>
    ///     <item>
    ///         <term>Android</term>
    ///         <description>✅</description>
    ///     </item>
    /// </list>
    /// <br />
    /// <b>Scopes required</b>
    /// <ul>
    ///     <li><see cref="Entitlements.Guilds"/>  for guild channels</li>
    ///     <li><see cref="Entitlements.Guilds"/> and <see cref="Entitlements.DmChannelsRead"/> for GDM channels. <c>DmChannelsRead</c> requires approval from Discord.</li>
    /// </ul>
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class GetChannelDiscordCommand : FrameDiscordCommand<GetChannelResponse>
    {
        internal override Command Command => Command.GET_CHANNEL;
     
        public GetChannelDiscordCommand([NotNull] string channelId)
        {
            ChannelId = channelId;
        }   
        
        [NotNull]
        [JsonProperty("channel_id")]
        public string ChannelId { [Preserve] get; set; }
    }
}