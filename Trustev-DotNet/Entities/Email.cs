using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class Email : BaseEntity
    {
        public Guid Id { get; set; }
        public String EmailAddress { get; set; }
        public Boolean IsDefault { get; set; }

        /// <summary>
        /// Post your Email to an existing Customer on an existing Case
        /// </summary>
        /// <param name="email">Your Email which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> PostAsync(string caseId, Email email)
        {
            string requestJson = JsonConvert.SerializeObject(email);

            string uri = String.Format("{0}/case/{1}/customer/email", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Post your Email to an existing Customer on an existing Case
        /// </summary>
        /// <param name="email">Your Email which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static Email Post(string caseId, Email email)
        {
            string requestJson = JsonConvert.SerializeObject(email);

            string uri = String.Format("{0}/case/{1}/customer/email", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Update a specific Email on a Case which already contains a Email
        /// </summary>
        /// <param name="emailId">The id of the Email you want to update</param>
        /// <param name="email">The Email you want to update the exisiting Email to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> UpdateAsync(string caseId, Email email, Guid emailId)
        {
            string requestJson = JsonConvert.SerializeObject(email);

            string uri = String.Format("{0}/case/{1}/customer/email/{2}", Trustev.BaseUrl, caseId, emailId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Update a specific Email on a Case which already contains a Email
        /// </summary>
        /// <param name="emailId">The id of the Email you want to update</param>
        /// <param name="email">The Email you want to update the exisiting Email to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Email Update(string caseId, Email email, Guid emailId)
        {
            string requestJson = JsonConvert.SerializeObject(email);

            string uri = String.Format("{0}/case/{1}/customer/email/{2}", Trustev.BaseUrl, caseId, emailId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific Email from a Case
        /// </summary>
        /// <param name="emailId">The Id of the Email you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> GetAsync(string caseId, Guid emailId)
        {
            string uri = String.Format("{0}/case/{1}/customer/email/{2}", Trustev.BaseUrl, caseId, emailId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific Email from a Case
        /// </summary>
        /// <param name="emailId">The Id of the Email you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static Email Get(string caseId, Guid emailId)
        {
            string uri = String.Format("{0}/case/{1}/customer/email/{2}", Trustev.BaseUrl, caseId, emailId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Email response = JsonConvert.DeserializeObject<Email>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Email>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer/email", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<Email> response = JsonConvert.DeserializeObject<List<Email>>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static IList<Email> Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer/email", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            IList<Email> response = JsonConvert.DeserializeObject<List<Email>>(responseString);

            return response;
        }
    }
}
