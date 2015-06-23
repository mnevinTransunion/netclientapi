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
        public string BINNumber { get; set; }

        /// <summary>
        /// Post your Payment to an existing Case
        /// </summary>
        /// <param name="payment">Your Payment which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Payment> PostAsync(string caseId, Payment payment)
        {
            string uri = string.Format(Constants.URI_PAYMENT_POST, Trustev.BaseUrl, caseId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Post, payment);

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
            string uri = string.Format(Constants.URI_PAYMENT_POST, Trustev.BaseUrl, caseId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Post, payment);

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
            string uri = string.Format(Constants.URI_PAYMENT_UPDATE, Trustev.BaseUrl, caseId, paymentId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Put, payment);

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
            string uri = string.Format(Constants.URI_PAYMENT_UPDATE, Trustev.BaseUrl, caseId, paymentId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Put, payment);

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
            string uri = string.Format(Constants.URI_PAYMENT_GET, Trustev.BaseUrl, caseId, paymentId);

            Payment response = await PerformHttpCallAsync<Payment>(uri, HttpMethod.Get, null);

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
            string uri = string.Format(Constants.URI_PAYMENT_GET, Trustev.BaseUrl, caseId, paymentId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<Payment>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_PAYMENT_GET, Trustev.BaseUrl, caseId, "");

            IList<Payment> response = await PerformHttpCallAsync<IList<Payment>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<Payment> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_PAYMENT_GET, Trustev.BaseUrl, caseId, "");

            IList<Payment> response = PerformHttpCall<IList<Payment>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
