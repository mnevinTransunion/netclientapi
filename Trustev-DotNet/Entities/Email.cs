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
        public string EmailAddress { get; set; }
        public Boolean IsDefault { get; set; }

        /// <summary>
        /// Post your Email to an existing Customer on an existing Case
        /// </summary>
        /// <param name="email">Your Email which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<Email> PostAsync(string caseId, Email email)
        {
            string uri = string.Format(Constants.URI_EMAIL_POST, Trustev.BaseUrl, caseId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Post, email);

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
            string uri = string.Format(Constants.URI_EMAIL_POST, Trustev.BaseUrl, caseId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Post, email);

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
            string uri = string.Format(Constants.URI_EMAIL_UDPATE, Trustev.BaseUrl, caseId, emailId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Put, email);

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
            string uri = string.Format(Constants.URI_EMAIL_UDPATE, Trustev.BaseUrl, caseId, emailId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Put, email);

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
            string uri = string.Format(Constants.URI_EMAIL_GET, Trustev.BaseUrl, caseId, emailId);

            Email response = await PerformHttpCallAsync<Email>(uri, HttpMethod.Get, null);

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
            string uri = string.Format(Constants.URI_EMAIL_GET, Trustev.BaseUrl, caseId, emailId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Email>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_EMAIL_GET, Trustev.BaseUrl, caseId, "");

            IList<Email> response = await PerformHttpCallAsync<IList<Email>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static IList<Email> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_EMAIL_GET, Trustev.BaseUrl, caseId, "");

            IList<Email> response = PerformHttpCall<IList<Email>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
