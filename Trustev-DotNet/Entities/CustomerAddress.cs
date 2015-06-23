using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class CustomerAddress : BaseEntity
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
        /// Post your CustomerAddress to an existing Customer on an existing Case
        /// </summary>
        /// <param name="customerAddress">Your CustomerAddress which you want to post</param>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> PostAsync(string caseId, CustomerAddress customerAddress)
        {
            string requestJson = JsonConvert.SerializeObject(customerAddress);

            string uri = String.Format("{0}/case/{1}/customer/address", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            CustomerAddress response = JsonConvert.DeserializeObject<CustomerAddress>(responseString);

            return response;
        }

        /// <summary>
        /// Update a specific CustomerAddress on a Case which already contains a CustomerAddresses
        /// </summary>
        /// <param name="customerAddressId">The id of the CustomerAddress you want to update</param>
        /// <param name="customerAddress">The CustomerAddress you want to update the exisiting CustomerAddress to</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> UpdateAsync(string caseId, CustomerAddress customerAddress, Guid customerAddressId)
        {
            string requestJson = JsonConvert.SerializeObject(customerAddress);

            string uri = String.Format("{0}/case/{1}/customer/address/{2}", Trustev.BaseUrl, caseId, customerAddressId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            CustomerAddress response = JsonConvert.DeserializeObject<CustomerAddress>(responseString);

            return response;
        }

        /// <summary>
        /// Get a specific customerAddress from a Case
        /// </summary>
        /// <param name="customerAddressId">The Id of the CustomerAddress you want to get</param>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static async Task<CustomerAddress> GetAsync(string caseId, Guid customerAddressId)
        {
            string uri = String.Format("{0}/case/{1}/customer/address/{2}", Trustev.BaseUrl, caseId, customerAddressId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            CustomerAddress response = JsonConvert.DeserializeObject<CustomerAddress>(responseString);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static async Task<IList<CustomerAddress>> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer/address", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            IList<CustomerAddress> response = JsonConvert.DeserializeObject<List<CustomerAddress>>(responseString);

            return response;
        }
    }
}
