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
        public String CaseNumber { get; set; }
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
            string requestJson = JsonConvert.SerializeObject(kase);

            string uri = String.Format("{0}/case", Trustev.BaseUrl);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post,  requestJson);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

            return response;
        }

        /// <summary>
        /// Post your Case to the Trustev Api
        /// </summary>
        /// <param name="kase">Your Case which you want to post</param>
        /// <returns>The Case along with the Id that Trustev have assigned it</returns>
        public static Case Post(Case kase)
        {
            string requestJson = JsonConvert.SerializeObject(kase);

            string uri = String.Format("{0}/case", Trustev.BaseUrl);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(kase);

            string uri = String.Format("{0}/case/{1}", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put,  requestJson);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(kase);

            string uri = String.Format("{0}/case/{1}", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static async Task<Case> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. Trustev will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static Case Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Case response = JsonConvert.DeserializeObject<Case>(responseString);

            return response;
        }

    }
}
