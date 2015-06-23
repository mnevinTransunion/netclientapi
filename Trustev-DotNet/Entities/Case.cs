using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trustev_DotNet.Entities.Internal;

namespace Trustev_DotNet.Entities
{
    public class Case : BaseEntity
    {
        public string Id { get; set; }
        public Guid SessionId { get; set; }
        public string CaseNumber { get; set; }
        public Transaction Transaction { get; set; }
        public Customer Customer { get; set; }
        public IList<CaseStatus> Statuses { get; set; }
        public IList<Payment> Payments { get; set; }
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Case constructor takes you sessionId and caseNumber as these are compulsory fields
        /// </summary>
        /// <param name="sessionId">This is your Trustev sessionId, This is available from the Trustev Javascript as a public variable TrustevV2.SessionId. It will need to be sent server side.</param>
        /// <param name="caseNumber">Your caseNumber. This is you unique idenitfier for thie Case.</param>
        public Case(Guid sessionId, string caseNumber)
        {
            SessionId = sessionId;
            CaseNumber = caseNumber;
            Statuses = new List<CaseStatus>();
            Payments = new List<Payment>();
        }

        /// <summary>
        /// Post your Case to the Trustev Api asynchronously
        /// </summary>
        /// <param name="kase">Your Case which you want to post</param>
        /// <returns>The Case along with the Id that Trustev have assigned it</returns>
        public static async Task<Case> PostAsync(Case kase)
        {
            string uri = string.Format(Constants.URI_CASE_POST, Trustev.BaseUrl);

            Case responseCase = await PerformHttpCallAsync<Case>(uri, HttpMethod.Post, kase);

            return responseCase;
        }

        /// <summary>
        /// Post your Case to the Trustev Api
        /// </summary>
        /// <param name="kase">Your Case which you want to post</param>
        /// <returns>The Case along with the Id that Trustev have assigned it</returns>
        public static Case Post(Case kase)
        {
            string uri = string.Format(Constants.URI_CASE_POST, Trustev.BaseUrl);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Post, kase);

            return response;
        }

        /// <summary>
        /// Update your Case with caseId provided with the new Case object asynchronously
        /// </summary>
        /// <param name="kase">Your Case which you want to Put and update the exisiting case with</param>
        /// <param name="caseId">The Case Id of the case you want to update. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static async Task<Case> UpdateAsync(Case kase, string caseId)
        {
            string uri = string.Format(Constants.URI_CASE_UPDATE, Trustev.BaseUrl, caseId);

            Case response = await PerformHttpCallAsync<Case>(uri, HttpMethod.Put, kase);

            return response;
        }

        /// <summary>
        /// Update your Case with caseId provided with the new Case object
        /// </summary>
        /// <param name="kase">Your Case which you want to Put and update the exisiting case with</param>
        /// <param name="caseId">The Case Id of the case you want to update. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static Case Update(Case kase, string caseId)
        {
            string uri = string.Format(Constants.URI_CASE_UPDATE, Trustev.BaseUrl, caseId);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Put, kase);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static async Task<Case> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_CASE_GET, Trustev.BaseUrl, caseId);

            Case response = await PerformHttpCallAsync<Case>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static Case Get(string caseId)
        {
            string uri = string.Format(Constants.URI_CASE_GET, Trustev.BaseUrl, caseId);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Get, null);

            return response;
        }

    }
}
