using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class SocialAccount : BaseEntity
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

        /// <summary>
        /// Post your SocialAccount to an existing Customer on an existing Case
        /// </summary>
        /// <param name="socialAccount">Your SocialAccount which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> PostAsync(string caseId, SocialAccount socialAccount)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_POST, Trustev.BaseUrl, caseId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Post, socialAccount);

            return response;
        }

        /// <summary>
        /// Post your SocialAccount to an existing Customer on an existing Case
        /// </summary>
        /// <param name="socialAccount">Your SocialAccount which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static SocialAccount Post(string caseId, SocialAccount socialAccount)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_POST, Trustev.BaseUrl, caseId);

            SocialAccount response = PerformHttpCall<SocialAccount>(uri, HttpMethod.Post, socialAccount);

            return response;
        }

        /// <summary>
        /// Update a specific SocialAccount on a Case which already contains a SocialAccount
        /// </summary>
        /// <param name="socialAccountId">The id of the SocialAccount you want to update</param>
        /// <param name="socialAccount">The SocialAccount you want to update the exisiting SocialAccount to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> UpdateAsync(string caseId, SocialAccount socialAccount, Guid socialAccountId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_UPDATE, Trustev.BaseUrl, caseId, socialAccountId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Put, socialAccount);

            return response;
        }

        /// <summary>
        /// Update a specific SocialAccount on a Case which already contains a SocialAccount
        /// </summary>
        /// <param name="socialAccountId">The id of the SocialAccount you want to update</param>
        /// <param name="socialAccount">The SocialAccount you want to update the exisiting SocialAccount to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static SocialAccount Update(string caseId, SocialAccount socialAccount, Guid socialAccountId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_UPDATE, Trustev.BaseUrl, caseId, socialAccountId);

            SocialAccount response = PerformHttpCall<SocialAccount>(uri, HttpMethod.Put, socialAccount);

            return response;
        }

        /// <summary>
        /// Get a specific SocialAccount from a Case
        /// </summary>
        /// <param name="socialAccountId">The Id of the SocialAccount you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> GetAsync(string caseId, Guid socialAccountId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_GET, Trustev.BaseUrl, caseId, socialAccountId);

            SocialAccount response = await PerformHttpCallAsync<SocialAccount>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a specific SocialAccount from a Case
        /// </summary>
        /// <param name="socialAccountId">The Id of the SocialAccount you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static SocialAccount Get(string caseId, Guid socialAccountId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_GET, Trustev.BaseUrl, caseId, socialAccountId);

            SocialAccount response = PerformHttpCall<SocialAccount>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the socialAccounts from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<SocialAccount>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_GET, Trustev.BaseUrl, caseId, "");

            IList<SocialAccount> response = await PerformHttpCallAsync<IList<SocialAccount>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the socialAccounts from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static IList<SocialAccount> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_SOCIALACCOUNT_GET, Trustev.BaseUrl, caseId, "");

            IList<SocialAccount> response = PerformHttpCall<IList<SocialAccount>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
