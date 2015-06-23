using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class Customer :BaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Email> Emails { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<CustomerAddress> Addresses { get; set; }
        public IList<SocialAccount> SocialAccounts { get; set; }

        /// <summary>
        /// Post your Customer to an existing Case
        /// </summary>
        /// <param name="customer">Your Customer which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Customer along with the Id that Trustev have assigned it</returns>
        public static async Task<Customer> PostAsync(string caseId, Customer customer)
        {
            string requestJson = JsonConvert.SerializeObject(customer);

            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }

        /// <summary>
        /// Post your Customer to an existing Case
        /// </summary>
        /// <param name="customer">Your Customer which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Customer along with the Id that Trustev have assigned it</returns>
        public static Customer Post(string caseId, Customer customer)
        {
            string requestJson = JsonConvert.SerializeObject(customer);

            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }

        /// <summary>
        /// Update the Customer on a Case which already contains a customer
        /// </summary>
        /// <param name="customer">Your Customer which you want to Put and update the exisiting Customer with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Customer> UpdateAsync(string caseId, Customer customer)
        {
            string requestJson = JsonConvert.SerializeObject(customer);

            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }

        /// <summary>
        /// Update the Customer on a Case which already contains a customer
        /// </summary>
        /// <param name="customer">Your Customer which you want to Put and update the exisiting Customer with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Customer Update(string caseId, Customer customer)
        {
            string requestJson = JsonConvert.SerializeObject(customer);

            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Customer attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Customer you want to get</param>
        /// <returns></returns>
        public static async Task<Customer> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Customer attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Customer you want to get</param>
        /// <returns></returns>
        public static Customer Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/customer", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Customer response = JsonConvert.DeserializeObject<Customer>(responseString);

            return response;
        }
    }
}
