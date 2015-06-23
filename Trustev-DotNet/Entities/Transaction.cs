﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev_DotNet.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid Id { get; set; }
        public decimal TotalTransactionValue { get; set; }
        public string Currency { get; set; }
        public DateTime Timestamp { get; set; }
        public IList<TransactionAddress> Addresses { get; set; }
        public IList<TransactionItem> Items { get; set; }

        /// <summary>
        /// Post your Transaction to an existing Case
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Transaction along with the Id that Trustev have assigned it</returns>
        public static async Task<Transaction> PostAsync(string caseId, Transaction transaction)
        {
            string requestJson = JsonConvert.SerializeObject(transaction);

            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Post, requestJson);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }

        /// <summary>
        /// Post your Transaction to an existing Case
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to post</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns>The Transaction along with the Id that Trustev have assigned it</returns>
        public static Transaction Post(string caseId, Transaction transaction)
        {
            string requestJson = JsonConvert.SerializeObject(transaction);

            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Post, requestJson);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }

        /// <summary>
        /// Update the Transaction on a Case which already contains a transaction
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to Put and update the exisiting Transaction with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static async Task<Transaction> UpdateAsync(string caseId, Transaction transaction)
        {
            string requestJson = JsonConvert.SerializeObject(transaction);

            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Put, requestJson);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }

        /// <summary>
        /// Update the Transaction on a Case which already contains a transaction
        /// </summary>
        /// <param name="transaction">Your Transaction which you want to Put and update the exisiting Transaction with</param>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static Transaction Update(string caseId, Transaction transaction)
        {
            string requestJson = JsonConvert.SerializeObject(transaction);

            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Put, requestJson);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Transaction attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Transaction you want to get</param>
        /// <returns></returns>
        public static async Task<Transaction> GetAsync(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = await PerformHttpCallAsync(uri, HttpMethod.Get);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }

        /// <summary>
        /// Get the Transaction attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Transaction you want to get</param>
        /// <returns></returns>
        public static Transaction Get(string caseId)
        {
            string uri = String.Format("{0}/case/{1}/transaction", Trustev.BaseUrl, caseId);

            string responseString = PerformHttpCall(uri, HttpMethod.Get);

            Transaction response = JsonConvert.DeserializeObject<Transaction>(responseString);

            return response;
        }
    }
}
