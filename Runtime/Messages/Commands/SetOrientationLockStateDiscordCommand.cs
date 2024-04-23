using System;
using DiscordActivitySdk.Messages.Events.Responses;
using DiscordActivitySdk.Messages.Model;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Commands
{
    /// <summary>
    /// Locks the application to specific orientations in each of the supported layout modes.
    /// <br /><br />
    /// <b>Supported Platforms</b>
    /// <list type="table">
    ///     <item>
    ///         <term>Web</term>
    ///         <description>⛔️</description>
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
    ///     <li><see cref="Entitlements.GuildsMemberRead"/></li>
    /// </ul>
    /// </summary>
    [PublicAPI]
    [Serializable]
    public class SetOrientationLockStateDiscordCommand : FrameDiscordCommand<EmptyResponse>
    {
        internal override Command Command => Command.SET_ORIENTATION_LOCK_STATE;
        
        [JsonProperty("lock_state")]
        public OrientationLockState LockState { [Preserve] get; set; }
        
        [CanBeNull]
        [JsonProperty("picture_in_picture_lock_state")]
        public OrientationLockState? PictureInPictureLockState { [Preserve] get; set; }
        [CanBeNull]
        [JsonProperty("grid_lock_state")]
        public OrientationLockState? GridLockState { [Preserve] get; set; }
    }
}