using System;

namespace Trustev.Domain.Entities
{
    /// <summary>
    /// The Customers social account details such as Social Id's, access tokens and secrets
    /// </summary>
    public class SocialAccount
    {
        public SocialAccount()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// This is the Social Account Id. This Id is returned when a Social Account object has been added to the Trustev API. This Id is required should you wish to update the Social Account details after a Trustev Case has been added. Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// This is the Social Network Id, i.e. Your Facebook Account Id
        /// </summary>
        public long SocialId { get; set; }

        /// <summary>
        /// This is your Trustev Social Network Type
        /// </summary>
        public Enums.SocialNetworkType Type { get; set; }

        /// <summary>
        /// This is the Short Term Access Token which is available from the Social Access Token you received from the relevant Social Network's API
        /// </summary>
        public string ShortTermAccessToken { get; set; }

        /// <summary>
        /// This is the Long Term Access Token which is available from the Social Access Token you received from the relevant Social Network's API
        /// </summary>
        public string LongTermAccessToken { get; set; }

        /// <summary>
        /// This is the Short Term Token Expiry datetime which is available from the Social Access Token you received from the relevant Social Network's API
        /// </summary>
        public DateTime ShortTermAccessTokenExpiry { get; set; }

        /// <summary>
        /// This is the Long Term Token Expiry datetime which is available from the Social Access Token you received from the relevant Social Network's API
        /// </summary>
        public DateTime LongTermAccessTokenExpiry { get; set; }

        /// <summary>
        /// This is the Secret which is attached to the Social Network's Developer's Account. This would have previously been needed to access the relevant Social Network's API
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// The Current DateTime in Utc. Defaults to DateTime.UtcNow
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
