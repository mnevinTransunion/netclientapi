using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class TransactionItem : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal ItemValue { get; set; }

        /// <summary>
        /// Post your TransactionItem to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionItem">Your TransactionItem which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> PostAsync(string caseId, TransactionItem transactionItem)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_POST, Trustev.BaseUrl, caseId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Post, transactionItem);

            return response;
        }

        /// <summary>
        /// Post your TransactionItem to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionItem">Your TransactionItem which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static TransactionItem Post(string caseId, TransactionItem transactionItem)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_POST, Trustev.BaseUrl, caseId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Post, transactionItem);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionItem on a Case which already contains a TransactionItem
        /// </summary>
        /// <param name="transactionItemId">The id of the TransactionItem you want to update</param>
        /// <param name="transactionItem">The TransactionAddress you want to update the exisiting TransactionItem to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> UpdateAsync(string caseId, TransactionItem transactionItem, Guid transactionItemId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_UPDATE, Trustev.BaseUrl, caseId, transactionItemId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Put, transactionItem);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionItem on a Case which already contains a TransactionItem
        /// </summary>
        /// <param name="transactionItemId">The id of the TransactionItem you want to update</param>
        /// <param name="transactionItem">The TransactionAddress you want to update the exisiting TransactionItem to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static TransactionItem Update(string caseId, TransactionItem transactionItem, Guid transactionItemId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_UPDATE, Trustev.BaseUrl, caseId, transactionItemId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Put, transactionItem);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionItem from a Case
        /// </summary>
        /// <param name="transactionItemId">The Id of the TransactionItem you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionItem> GetAsync(string caseId, Guid transactionItemId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, Trustev.BaseUrl, caseId, transactionItemId);

            TransactionItem response = await PerformHttpCallAsync<TransactionItem>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionItem from a Case
        /// </summary>
        /// <param name="transactionItemId">The Id of the TransactionItem you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static TransactionItem Get(string caseId, Guid transactionItemId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, Trustev.BaseUrl, caseId, transactionItemId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the TransacitonItems from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<TransactionItem>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, Trustev.BaseUrl, caseId, "");

            IList<TransactionItem> response = await PerformHttpCallAsync<IList<TransactionItem>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the TransacitonItems from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static IList<TransactionItem> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONITEM_GET, Trustev.BaseUrl, caseId, "");

            IList<TransactionItem> response = PerformHttpCall<IList<TransactionItem>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
