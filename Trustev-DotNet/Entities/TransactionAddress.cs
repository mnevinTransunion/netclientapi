using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class TransactionAddress : BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int Type { get; set; }
        public string CountryCode { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsDefault { get; set; }

        /// <summary>
        /// Post your TransactionAddress to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionAddress">Your TransactionAddress which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> PostAsync(string caseId, TransactionAddress transactionAddress)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_POST, Trustev.BaseUrl, caseId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Post, transactionAddress);

            return response;
        }

        /// <summary>
        /// Post your TransactionAddress to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="transactionAddress">Your TransactionAddress which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static TransactionAddress Post(string caseId, TransactionAddress transactionAddress)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_POST, Trustev.BaseUrl, caseId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Post, transactionAddress);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionAddress on a Case which already contains a TransactionAddress
        /// </summary>
        /// <param name="transactionAddressId">The id of the TransactionAddress you want to update</param>
        /// <param name="transactionAddress">The TransactionAddress you want to update the exisiting TransactionAddress to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> UpdateAsync(string caseId, TransactionAddress transactionAddress, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_UPDATE, Trustev.BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Put, transactionAddress);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionAddress on a Case which already contains a TransactionAddress
        /// </summary>
        /// <param name="transactionAddressId">The id of the TransactionAddress you want to update</param>
        /// <param name="transactionAddress">The TransactionAddress you want to update the exisiting TransactionAddress to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static TransactionAddress Update(string caseId, TransactionAddress transactionAddress, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_UPDATE, Trustev.BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Put, transactionAddress);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionAddress from a Case
        /// </summary>
        /// <param name="transactionAddressId">The Id of the TransactionAddress you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<TransactionAddress> GetAsync(string caseId, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_GET, Trustev.BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = await PerformHttpCallAsync<TransactionAddress>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionAddress from a Case
        /// </summary>
        /// <param name="transactionAddressId">The Id of the TransactionAddress you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static TransactionAddress Get(string caseId, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_GET, Trustev.BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<TransactionAddress>> GetAsync(string caseId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_GET, Trustev.BaseUrl, caseId, "");

            IList<TransactionAddress> response = await PerformHttpCallAsync<IList<TransactionAddress>>(uri, HttpMethod.Get, null);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static IList<TransactionAddress> Get(string caseId)
        {
            string uri = string.Format(Constants.URI_TRANSACTIONADDRESS_GET, Trustev.BaseUrl, caseId, "");

            IList<TransactionAddress> response = PerformHttpCall<IList<TransactionAddress>>(uri, HttpMethod.Get, null);

            return response;
        }
    }
}
