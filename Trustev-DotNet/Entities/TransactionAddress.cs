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
        public String CountryCode { get; set; }
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
            string requestJson = JsonConvert.SerializeObject(transactionAddress);

            string uri = String.Format("{0}/case/{1}/transaction/address", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(transactionAddress);

            string uri = String.Format("{0}/case/{1}/transaction/address", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(transactionAddress);

            string uri = String.Format("{0}/case/{1}/transaction/address/{2}", Trustev.BaseUrl, caseId, transactionAddressId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

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
            string requestJson = JsonConvert.SerializeObject(transactionAddress);

            string uri = String.Format("{0}/case/{1}/transaction/address/{2}", Trustev.BaseUrl, caseId, transactionAddressId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

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
            string uri = String.Format("{0}/case/{1}/transaction/address/{2}", Trustev.BaseUrl, caseId, transactionAddressId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

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
            string uri = String.Format("{0}/case/{1}/transaction/address/{2}", Trustev.BaseUrl, caseId, transactionAddressId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            TransactionAddress response = JsonConvert.DeserializeObject<TransactionAddress>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<TransactionAddress>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/transaction/address", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<TransactionAddress> response = JsonConvert.DeserializeObject<List<TransactionAddress>>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static IList<TransactionAddress> Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/transaction/address", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            IList<TransactionAddress> response = JsonConvert.DeserializeObject<List<TransactionAddress>>(responseString);

            return response;
        }
    }
}
