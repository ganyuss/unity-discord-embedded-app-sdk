using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DiscordActivitySdk.Messages.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum ConsoleLevel
    {
        [EnumMember(Value = "log")]
        Log,
        [EnumMember(Value = "debug")]
        Debug,
        [EnumMember(Value = "info")]
        Info,
        [EnumMember(Value = "warn")]
        Warning,
        [EnumMember(Value = "error")]
        Error
    }
}