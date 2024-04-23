using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [Serializable]
    [Preserve]
    [PublicAPI]
    public class Entitlement
    {
        [JsonProperty("id")]
        public string Id { [Preserve] get; [Preserve] set; }
        [JsonProperty("sku_id")]
        public string SkuId { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("application_id")]
        public string ApplicationId { [Preserve] get; [Preserve] set; }
        [JsonProperty("user_id")]
        public string UserId { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("gift_code_flags")]
        public int GiftCodeFlags { [Preserve] get; [Preserve] set; }
        
        [JsonProperty("type")]
        public EntitlementType Type { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("gifter_user_id")]
        public string GifterUserId { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("branches")]
        public string[] Branches { [Preserve] get; [Preserve] set; }
        
        [CanBeNull] 
        [JsonProperty("starts_at")]
        public string StartsAtString { [Preserve] get; [Preserve] set; }
        [CanBeNull] 
        public DateTime? StartsAt => TryParseDateIso(StartsAtString);

        [CanBeNull] 
        [JsonProperty("ends_at")]
        public string EndsAtString { [Preserve] get; [Preserve] set; }
        [CanBeNull] 
        public DateTime? EndsAt => TryParseDateIso(EndsAtString);
        
        [CanBeNull]
        [JsonProperty("parent_id")]
        public string ParentId { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("consumed")]
        public bool? Consumed { [Preserve] get; [Preserve] set; }
        [CanBeNull]
        [JsonProperty("deleted")]
        public bool? Deleted { [Preserve] get; [Preserve] set; }
        
        [CanBeNull]
        [JsonProperty("gift_code_batch_id")]
        public string GiftCodeBatchId { [Preserve] get; [Preserve] set; }
        
        

        [CanBeNull] 
        private DateTime? TryParseDateIso([CanBeNull] string isoDateString)
        {
            if (isoDateString == null)
                return null;

            if (! DateTime.TryParse(isoDateString, out var output))
                return null;

            return output;
        }
    }
}