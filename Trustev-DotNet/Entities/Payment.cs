using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class Payment : BaseEntity
    {
        public Guid Id { get; set; }
        public Enums.PaymentType PaymentType { get; set; }
        public String BINNumber { get; set; }

        /// <summary>
        /// Post your Payment to an existing Case
        /// </summary>
        /// <param name="payment">Your Payment which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> PostAsync(string caseId, Payment payment)
        {
            string requestJson = JsonConvert.SerializeObject(payment);

            string uri = String.Format("{0}/case/{1}/payment", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Post your Payment to an existing Case
        /// </summary>
        /// <param name="payment">Your Payment which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Payment Post(string caseId, Payment payment)
        {
            string requestJson = JsonConvert.SerializeObject(payment);

            string uri = String.Format("{0}/case/{1}/payment", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Update a specific Payment on a Case which already contains a Payments
        /// </summary>
        /// <param name="paymentId">The id of the Payment you want to update</param>
        /// <param name="payment">The Payment you want to update the exisiting Payment to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> UpdateAsync(string caseId, Payment payment, Guid paymentId)
        {
            string requestJson = JsonConvert.SerializeObject(payment);

            string uri = String.Format("{0}/case/{1}/payment/{2}", Trustev.BaseUrl, caseId, paymentId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Update a specific Payment on a Case which already contains a Payments
        /// </summary>
        /// <param name="paymentId">The id of the Payment you want to update</param>
        /// <param name="payment">The Payment you want to update the exisiting Payment to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Payment Update(string caseId, Payment payment, Guid paymentId)
        {
            string requestJson = JsonConvert.SerializeObject(payment);

            string uri = String.Format("{0}/case/{1}/payment/{2}", Trustev.BaseUrl, caseId, paymentId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific Payment from a Case
        /// </summary>
        /// <param name="paymentId">The Id of the Payment you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> GetAsync(string caseId, Guid paymentId)
        {
            string uri = String.Format("{0}/case/{1}/payment/{2}", Trustev.BaseUrl, caseId, paymentId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific Payment from a Case
        /// </summary>
        /// <param name="paymentId">The Id of the Payment you want to get</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Payment Get(string caseId, Guid paymentId)
        {
            string uri = String.Format("{0}/case/{1}/payment/{2}", Trustev.BaseUrl, caseId, paymentId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Payment response = JsonConvert.DeserializeObject<Payment>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Payment>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/payment", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<Payment> response = JsonConvert.DeserializeObject<List<Payment>>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<Payment> Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/payment", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            IList<Payment> response = JsonConvert.DeserializeObject<List<Payment>>(responseString);

            return response;
        }
    }
}
