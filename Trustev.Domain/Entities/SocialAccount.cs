using System;

namespace Trustev.Domain.Entities
{
    public class SocialAccount
    {
        public Guid Id { get; set; }
        public long SocialId { get; set; }
        public Enums.SocialNetworkType Type { get; set; }
        public string ShortTermAccessToken { get; set; }
        public string LongTermAccessToken { get; set; }
        public DateTime ShortTermAccessTokenExpiry { get; set; }
        public DateTime LongTermAccessTokenExpiry { get; set; }
        public string Secret { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
