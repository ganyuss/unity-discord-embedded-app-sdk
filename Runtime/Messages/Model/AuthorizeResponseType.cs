using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DiscordActivitySdk.Messages.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    [PublicAPI]
    public enum AuthorizeResponseType
    {
        [EnumMember(Value = "code")]
        Code,
        [EnumMember(Value = "token")]
        Token
    }
}