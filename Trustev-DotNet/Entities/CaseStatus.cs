using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class CaseStatus : BaseEntity
    {
        public Guid Id { get; set; }
        public Enums.CaseStatusType Status { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Post your CaseStatus to an existing Case
        /// </summary>
        /// <param name="caseStatus">Your CaseStatus which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CaseStatus> PostAsync(string caseId, CaseStatus caseStatus)
        {
            string requestJson = JsonConvert.SerializeObject(caseStatus);

            string uri = String.Format("{0}/case/{1}/status", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            CaseStatus response = JsonConvert.DeserializeObject<CaseStatus>(responseString);

            return response;
        }

        /// <summary>
        /// Post your CaseStatus to an existing Case
        /// </summary>
        /// <param name="caseStatus">Your CaseStatus which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static CaseStatus Post(string caseId, CaseStatus caseStatus)
        {
            string requestJson = JsonConvert.SerializeObject(caseStatus);

            string uri = String.Format("{0}/case/{1}/status", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            CaseStatus response = JsonConvert.DeserializeObject<CaseStatus>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific status from a Case
        /// </summary>
        /// <param name="caseStatusId">The Id of the CaseStatus you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CaseStatus> GetAsync(string caseId, Guid caseStatusId)
        {
            string uri = String.Format("{0}/case/{1}/status/{2}", Trustev.BaseUrl, caseId, caseStatusId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            CaseStatus response = JsonConvert.DeserializeObject<CaseStatus>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific status from a Case
        /// </summary>
        /// <param name="caseStatusId">The Id of the CaseStatus you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static CaseStatus Get(string caseId, Guid caseStatusId)
        {
            string uri = String.Format("{0}/case/{1}/status/{2}", Trustev.BaseUrl, caseId, caseStatusId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            CaseStatus response = JsonConvert.DeserializeObject<CaseStatus>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<CaseStatus>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/status", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<CaseStatus> response = JsonConvert.DeserializeObject<List<CaseStatus>>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<CaseStatus> Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/status", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            IList<CaseStatus> response = JsonConvert.DeserializeObject<List<CaseStatus>>(responseString);

            return response;
        }
    }
}
