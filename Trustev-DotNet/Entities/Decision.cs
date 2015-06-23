using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class Decision : BaseEntity
    {
        public Guid Id { get; set; }

        public string CaseId { get; set; }

        public int Version { get; set; }

        public Guid SessionId { get; set; }

        public DateTime Timestamp { get; set; }

        public int Type { get; set; }

        public Enums.DecisionResult Result { get; set; }

        public int Score { get; set; }

        public int Confidence { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// Get a Decision on a Case with Id caseId.
        /// </summary>
        /// <param name="caseId">The Id of a Case which you have already posted to the Trustev API.</param>
        /// <returns></returns>
        public static async Task<Decision> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/decision/{1}", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Decision decision = JsonConvert.DeserializeObject<Decision>(responseString);

            decision.CaseId = caseId;

            return decision;
        }

        /// <summary>
        /// Get a Decision on a Case with Id caseId.
        /// </summary>
        /// <param name="caseId">The Id of a Case which you have already posted to the Trustev API.</param>
        /// <returns></returns>
        public static Decision Get(string caseId)
        {
            string uri = String.Format("{0}/decision/{1}", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Decision decision = JsonConvert.DeserializeObject<Decision>(responseString);

            decision.CaseId = caseId;

            return decision;
        }

        /// <summary>
        /// This method will post the Case you provide and then get a Decison for that case. 
        /// </summary>
        /// <param name="kase">A Trustev Case which you have not already posted which you want a Decsion for.</param>
        /// <returns></returns>
        public static async Task<Decision> GetAsync(Case kase)
        {
            Case returnCase = await Case.PostAsync(kase);

            Decision decision = await GetAsync(returnCase.Id);

            return decision;
        }

        /// <summary>
        /// This method will post the Case you provide and then get a Decison for that case. 
        /// </summary>
        /// <param name="kase">A Trustev Case which you have not already posted which you want a Decsion for.</param>
        /// <returns></returns>
        public static Decision Get(Case kase)
        {
            Case returnCase = Case.Post(kase);

            Decision decision = Get(returnCase.Id);

            return decision;
        }
    }
}
