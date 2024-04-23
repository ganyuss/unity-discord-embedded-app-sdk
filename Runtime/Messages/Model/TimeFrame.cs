using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    [Serializable]
    [Preserve]
    public class TimeFrame
    {
        [CanBeNull]
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTimeTicks { [Preserve] get; [Preserve] set; }

        [CanBeNull]
        [JsonIgnore]
        public DateTime? StartTime
        {
            get => StartTimeTicks != null ? new DateTime(StartTimeTicks.Value) : null;
            set => StartTimeTicks = value?.Ticks;
        }
        
        [CanBeNull]
        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndTimeTicks { [Preserve] get; [Preserve] set; }

        [CanBeNull]
        [JsonIgnore]
        public DateTime? EndTime
        {
            get => EndTimeTicks != null ? new DateTime(EndTimeTicks.Value) : null;
            set => EndTimeTicks = value?.Ticks;
        }
    }
}