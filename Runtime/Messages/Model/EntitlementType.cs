using JetBrains.Annotations;

namespace DiscordActivitySdk.Messages.Model
{
    [PublicAPI]
    public enum EntitlementType
    {
        UNHANDLED = -1,
        PURCHASE = 1,
        PREMIUM_SUBSCRIPTION = 2,
        DEVELOPER_GIFT = 3,
        TEST_MODE_PURCHASE = 4,
        FREE_PURCHASE = 5,
        USER_GIFT = 6,
        PREMIUM_PURCHASE = 7,
    }
}