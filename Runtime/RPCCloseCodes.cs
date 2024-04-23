namespace DiscordActivitySdk
{
    public enum RPCCloseCodes {
        CLOSE_NORMAL = 1000,
        CLOSE_UNSUPPORTED = 1003,
        CLOSE_ABNORMAL = 1006,
        INVALID_CLIENTID = 4000,
        INVALID_ORIGIN = 4001,
        RATELIMITED = 4002,
        TOKEN_REVOKED = 4003,
        INVALID_VERSION = 4004,
        INVALID_ENCODING = 4005
    }
}
