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
        public String ShortTermAccessToken { get; set; }
        public String LongTermAccessToken { get; set; }
        public DateTime ShortTermAccessTokenExpiry { get; set; }
        public DateTime LongTermAccessTokenExpiry { get; set; }
        public String Secret { get; set; }
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Post your SocialAccount to an existing Customer on an existing Case
        /// </summary>
        /// <param name="socialAccount">Your SocialAccount which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<SocialAccount> PostAsync(string caseId, SocialAccount socialAccount)
        {
            string requestJson = JsonConvert.SerializeObject(socialAccount);

            string uri = String.Format("{0}/case/{1}/customer/socialaccount", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(socialAccount);

            string uri = String.Format("{0}/case/{1}/customer/socialaccount", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(socialAccount);

            string uri = String.Format("{0}/case/{1}/customer/socialaccount/{2}", Trustev.BaseUrl, caseId, socialAccountId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(socialAccount);

            string uri = String.Format("{0}/case/{1}/customer/socialaccount/{2}", Trustev.BaseUrl, caseId, socialAccountId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

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
            string uri = String.Format("{0}/case/{1}/customer/socialaccount/{2}", Trustev.BaseUrl, caseId, socialAccountId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

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
            string uri = String.Format("{0}/case/{1}/customer/socialaccount/{2}", Trustev.BaseUrl, caseId, socialAccountId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            SocialAccount response = JsonConvert.DeserializeObject<SocialAccount>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the socialAccounts from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<SocialAccount>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer/socialaccount", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<SocialAccount> response = JsonConvert.DeserializeObject<List<SocialAccount>>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the socialAccounts from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static IList<SocialAccount> Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer/socialaccount", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            IList<SocialAccount> response = JsonConvert.DeserializeObject<List<SocialAccount>>(responseString);

            return response;
        }
    }
}
