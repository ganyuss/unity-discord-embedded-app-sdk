using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Preserve]
    [Serializable]
    public class Message
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("channel_id")]
        public string ChannelId { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("guild_id")]
        public string GuildId { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("author")]
        public User Author { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("member")]
        public GuildMember Member { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("content")]
        public string Content { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("timestamp")]
        public string TimeStampString { [Preserve] get; [Preserve] set; }
        public DateTime TimeStamp => DateTime.Parse(TimeStampString);
        [JsonProperty("edited_timestamp")]
        public string EditedTimeStampString { [Preserve] get; [Preserve] set; }
        public DateTime EditedTimeStamp => DateTime.Parse(EditedTimeStampString);
        
        [JsonProperty("tts")]
        public bool TextToSpeech { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("mention_everyone")]
        public bool MentionEveryone { [Preserve] get; [Preserve] set; }
        [JsonProperty("mentions")]
        public User[] Mentions { [Preserve] get; [Preserve] set; }
        [JsonProperty("mention_roles")]
        public string[] MentionRoles { [Preserve] get; [Preserve] set; }
        [JsonProperty("mention_channels")]
        public ChannelMention[] MentionChannels { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("attachments")]
        public Attachment[] Attachments { [Preserve] get; [Preserve] set; }
        [JsonProperty("embeds")]
        public Embed[] Embeds { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("reactions")]
        public Reaction[] Reactions { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("nonce")]
        public object Nonce { [Preserve] get; [Preserve] set; }
        public int? NonceInt => Nonce as int?;
        [CanBeNull]
        public string NonceString => Nonce as string;
        
        [JsonProperty("pinned")]
        public bool Pinned { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("webhook_id")]
        public string WebhookId { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("type")]
        public int Type { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("activity")]
        public MessageActivity Activity { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("application")]
        public MessageApplication Application { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("message_reference")]
        public MessageReference MessageReference { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("flags")]
        public int? Flags { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("stickers")]
        public object[] Stickers { [Preserve] get; [Preserve] set; }
        /// <summary>
        /// Cannot self reference, but this is possibly a Message
        /// </summary>
        [CanBeNull]
        [JsonProperty("referenced_message")]
        public object ReferencedMessage { [Preserve] get; [Preserve] set; }
    }
}