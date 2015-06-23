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
            string uri = string.Format(Constants.URI_CASESTATUS_POST, Trustev.BaseUrl, caseId);

            CaseStatus response = await PerformHttpCallAsync<CaseStatus>(uri, HttpMethod.Post, caseStatus);

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
            string uri = string.Format(Constants.URI_CASESTATUS_POST, Trustev.BaseUrl, caseId);

            CaseStatus response = PerformHttpCall<CaseStatus>(uri, HttpMethod.Post, caseStatus);

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
            string uri = string.Format(Constants.URI_CASESTATUS_GET, Trustev.BaseUrl, caseId, caseStatusId);

            CaseStatus response = await PerformHttpCallAsync<CaseStatus>(uri, HttpMethod.Get, null);

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
            string uri = string.Format(Constants.URI_CASESTATUS_GET, Trustev.BaseUrl, caseId, caseStatusId);

            CaseStatus response = PerformHttpCall<CaseStatus>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<CaseStatus>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_CASESTATUS_GET, Trustev.BaseUrl, caseId, "");

            IList<CaseStatus> response = await PerformHttpCallAsync<IList<CaseStatus>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<CaseStatus> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_CASESTATUS_GET, Trustev.BaseUrl, caseId, "");

            IList<CaseStatus> response = PerformHttpCall<IList<CaseStatus>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
