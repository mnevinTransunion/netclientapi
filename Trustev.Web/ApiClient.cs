using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Trustev.Domain;
using Trustev.Domain.Entities;
using Trustev.Domain.Exceptions;

namespace Trustev.Web
{
    /// <summary>
    /// The ApiClient has all the methods required to communicate with the Trustev Platform.
    /// </summary>
    public static class ApiClient
    {
        internal static string UserName { get; set; }

        internal static string Password { get; set; }

        internal static string Secret { get; set; }

        internal static string PublicKey { get; set; }

        internal static string BaseUrl { get; set; }

        internal static int HttpRequestTimeout { get; set; }

        static ApiClient()
        {
            UserName = "";
            Password = "";
            Secret = "";
            BaseUrl = "";
        }

        /// <summary>
        /// Initialize the Trustev class by passing in your UserName, Password, Secret, and BaseUrl - This could be EU or US, depending on your location.
        /// </summary>
        /// <param name="userName">Your ApiClient UserName</param>
        /// <param name="password">Your ApiClient Password</param>
        /// <param name="secret">Your ApiClient Secret</param>
        /// <param name="baseUrl">Your BaseURL - US/EU</param>
        /// <param name="httpRequestTimeout">Your default httpRequestTimeout</param>
        public static void SetUp(string userName, string password, string secret, Enums.BaseUrl baseUrl, int httpRequestTimeout = 15000)
        {
            UserName = userName;
            Password = password;
            Secret = secret;

            if (baseUrl.Equals(Enums.BaseUrl.EU))
            {
                BaseUrl = "https://app-eu.trustev.com/api/v2.0";
            }
            else if (baseUrl.Equals(Enums.BaseUrl.US))
            {
                BaseUrl = "https://app.trustev.com/api/v2.0";
            }

            HttpRequestTimeout = httpRequestTimeout;
        }

        /// <summary>
        /// Initialize the Trustev class by passing in your UserName, Password, Secret, and BaseUrl - This could be EU or US, depending on your location.
        /// </summary>
        /// <param name="userName">Your ApiClient UserName</param>
        /// <param name="password">Your ApiClient Password</param>
        /// <param name="secret">Your ApiClient Secret</param>
        /// <param name="publicKey">Your ApiClient Public Key</param>
        /// <param name="baseUrl">Your BaseURL - US/EU</param>
        /// <param name="httpRequestTimeout">The timeout value of this http request in milliseconds</param>
        public static void SetUp(string userName, string password, string secret, string publicKey, Enums.BaseUrl baseUrl, int httpRequestTimeout = 15000)
        {
            UserName = userName;
            Password = password;
            Secret = secret;
            PublicKey = publicKey;

            if (baseUrl.Equals(Enums.BaseUrl.EU))
            {
                BaseUrl = "https://app-eu.trustev.com/api/v2.0";
            }
            else if (baseUrl.Equals(Enums.BaseUrl.US))
            {
                BaseUrl = "https://app.trustev.com/api/v2.0";
            }

            HttpRequestTimeout = httpRequestTimeout;
        }

        /// <summary>
        /// Initialize the Trustev class by passing in your UserName, Password, Secret, and BaseUrl
        /// </summary>
        /// <param name="userName">Your ApiClient UserName</param>
        /// <param name="password">Your ApiClient Password</param>
        /// <param name="secret">Your ApiClient Secret</param>
        /// <param name="baseUrl">Your BaseURL - specified through a url string</param>
        /// <param name="httpRequestTimeout">Your default httpRequestTimeout</param>
        public static void SetUp(string userName, string password, string secret, string baseUrl, int httpRequestTimeout = 15000)
        {
            UserName = userName;
            Password = password;
            Secret = secret;
            BaseUrl = baseUrl;
            HttpRequestTimeout = httpRequestTimeout;
        }

        /// <summary>
        /// Initialize the Trustev class by passing in your UserName, Password, Secret, PublicKey, and BaseUrl
        /// </summary>
        /// <param name="userName">Your ApiClient UserName</param>
        /// <param name="password">Your ApiClient Password</param>
        /// <param name="secret">Your ApiClient Secret</param>
        /// <param name="publicKey">Your ApiClient Public Key</param>
        /// <param name="baseUrl">Your BaseURL - specified through a url string</param>
        /// <param name="httpRequestTimeout">Your default httpRequestTimeout</param>
        public static void SetUp(string userName, string password, string secret, string publicKey, string baseUrl, int httpRequestTimeout = 15000)
        {
            UserName = userName;
            Password = password;
            PublicKey = publicKey;
            Secret = secret;
            BaseUrl = baseUrl;
            HttpRequestTimeout = httpRequestTimeout;
        }

        /// <summary>
        /// Post your Case to the TrustevClient Api
        /// </summary>
        /// <param name="session">Your Session which you want to post</param>
        /// <returns>The Session along with the Id that TrustevClient have assigned it</returns>
        public static Session PostSession(Session session)
        {
            string uri = string.Format(Constants.UriSessionPost, BaseUrl);

            Session response = PerformHttpCall<Session>(uri, HttpMethod.Post, session, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your Detail to an existing Session
        /// </summary>
        /// <param name="sessionId">The Id of the session you want to add the detail to. It comes back as part of the Session Post Response</param>
        /// <param name="detail">Your Detail which you want to post</param>
        /// <returns>The Session along with the Id that TrustevClient have assigned it</returns>
        public static Detail PostDetail(Guid sessionId, Detail detail)
        {
            string uri = string.Format(Constants.UriDetailPost, BaseUrl, sessionId);

            Detail response = PerformHttpCall<Detail>(uri, HttpMethod.Post, detail, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your Case to the TrustevClient Api
        /// </summary>
        /// <param name="kase">Your Case which you want to post</param>
        /// <returns>The Case along with the Id that TrustevClient have assigned it</returns>
        public static Case PostCase(Case kase)
        {
            string uri = string.Format(Constants.UriCasePost, BaseUrl);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Post, kase, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update your Case with caseId provided with the new Case object
        /// </summary>
        /// <param name="kase">Your Case which you want to Put and update the existing case with</param>
        /// <param name="caseId">The Case Id of the case you want to update. TrustevClient will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static Case UpdateCase(Case kase, string caseId)
        {
            string uri = string.Format(Constants.UriCaseUpdate, BaseUrl, caseId);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Put, kase, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get the Case with the Id caseId
        /// </summary>
        /// <param name="caseId">The case Id of the Case you want to get. TrustevClient will have assigned this Id and returned it in the response Case from the Case post Method</param>
        /// <returns></returns>
        public static Case GetCase(string caseId)
        {
            string uri = string.Format(Constants.UriCaseGet, BaseUrl, caseId);

            Case response = PerformHttpCall<Case>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a Decision on a Case with Id caseId.
        /// </summary>
        /// <param name="caseId">The Id of a Case which you have already posted to the TrustevClient API.</param>
        /// <returns></returns>
        public static Decision GetDecision(string caseId)
        {
            string uri = string.Format(Constants.UriDecisionGet, BaseUrl, caseId);

            Decision decision = PerformHttpCall<Decision>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            decision.CaseId = caseId;

            return decision;
        }

        /// <summary>
        /// Get a Detailed Decision on a Case with Id caseId.
        /// </summary>
        /// <param name="caseId">The Id of a Case which you have already posted to the TrustevClient API.</param>
        /// <returns></returns>
        public static DetailedDecision GetDetailedDecision(string caseId)
        {
            string uri = string.Format(Constants.UriDetailedDecisionGet, BaseUrl, caseId);

            DetailedDecision detailedDecision = PerformHttpCall<DetailedDecision>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            detailedDecision.CaseId = caseId;

            return detailedDecision;
        }

        /// <summary>
        /// Use this endpoint and HTTP method to Request OR Regenerate a OTP to a previously created Trustev Case.
        /// </summary>
        /// <param name="caseId">
        /// CaseId - This is returned in the Response Header when a Trustev Case is created. 
        /// </param>
        /// <param name="request">
        /// Status Request Object 
        /// </param>
        /// <returns>
        /// </returns>
        public static OTPResult PostOtp(string caseId, OTPResult request)
        {
            var uri = string.Format(Constants.UriOtp, BaseUrl, caseId);

            var digitalAuthenticationResult = PerformHttpCall<OTPResult>(uri, HttpMethod.Post, request, true, HttpRequestTimeout);
            return digitalAuthenticationResult;
        }

        /// <summary>
        /// Use this endpoint and HTTP method to Request a OTP Verification to a previously created OTP.
        /// </summary>
        /// <param name="caseId">
        /// CaseId - This is returned in the Response Header when a Trustev Case is created. 
        /// </param>
        /// <param name="request">
        /// Status Request Object 
        /// </param>
        /// <returns>
        /// </returns>
        public static OTPResult PutOtp(string caseId, OTPResult request)
        {
            var uri = string.Format(Constants.UriOtp, BaseUrl, caseId);

            var digitalAuthenticationResult = PerformHttpCall<OTPResult>(uri, HttpMethod.Put, request, true, HttpRequestTimeout);
            return digitalAuthenticationResult;
        }

        /// <summary>
        /// Post your Customer to an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="customer">Your Customer which you want to post</param>
        /// <returns></returns>
        public static Customer PostCustomer(string caseId, Customer customer)
        {
            string uri = string.Format(Constants.UriCustomerPost, BaseUrl, caseId);

            Customer response = PerformHttpCall<Customer>(uri, HttpMethod.Post, customer, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update the Customer on a Case which already contains a customer
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="customer">Your Customer which you want to Put and update the existing Customer with</param>
        /// <returns></returns>
        public static Customer UpdateCustomer(string caseId, Customer customer)
        {
            string uri = string.Format(Constants.UriCustomerUpdate, BaseUrl, caseId);

            Customer response = PerformHttpCall<Customer>(uri, HttpMethod.Put, customer, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get the Customer attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Customer you want to get</param>
        /// <returns></returns>
        public static Customer GetCustomer(string caseId)
        {
            string uri = string.Format(Constants.UriCustomerGet, BaseUrl, caseId);

            Customer response = PerformHttpCall<Customer>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your Transaction to an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="transaction">Your Transaction which you want to post</param>
        /// <returns></returns>
        public static Transaction PostTransaction(string caseId, Transaction transaction)
        {
            string uri = string.Format(Constants.UriTransactionPost, BaseUrl, caseId);

            Transaction response = PerformHttpCall<Transaction>(uri, HttpMethod.Post, transaction, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update the Transaction on a Case which already contains a transaction
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="transaction">Your Transaction which you want to Put and update the existing Transaction with</param>
        /// <returns></returns>
        public static Transaction UpdateTransaction(string caseId, Transaction transaction)
        {
            string uri = string.Format(Constants.UriTransactionUpdate, BaseUrl, caseId);

            Transaction response = PerformHttpCall<Transaction>(uri, HttpMethod.Put, transaction, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get the Transaction attached to the Case
        /// </summary>
        /// <param name="caseId">The case Id of the the Case with the Transaction you want to get</param>
        /// <returns></returns>
        public static Transaction GetTransaction(string caseId)
        {
            string uri = string.Format(Constants.UriTransactionGet, BaseUrl, caseId);

            Transaction response = PerformHttpCall<Transaction>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your CaseStatus to an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="caseStatus">Your CaseStatus which you want to post</param>
        /// <returns></returns>
        public static CaseStatus PostCaseStatus(string caseId, CaseStatus caseStatus)
        {
            string uri = string.Format(Constants.UriCaseStatusPost, BaseUrl, caseId);

            CaseStatus response = PerformHttpCall<CaseStatus>(uri, HttpMethod.Post, caseStatus, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific status from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="caseStatusId">The Id of the CaseStatus you want to get</param>
        /// <returns></returns>
        public static CaseStatus GetCaseStatus(string caseId, Guid caseStatusId)
        {
            string uri = string.Format(Constants.UriCaseStatusGet, BaseUrl, caseId, caseStatusId);

            CaseStatus response = PerformHttpCall<CaseStatus>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a all the statuses from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<CaseStatus> GetCaseStatuses(string caseId)
        {
            string uri = string.Format(Constants.UriCaseStatusesGet, BaseUrl, caseId);

            IList<CaseStatus> response = PerformHttpCall<IList<CaseStatus>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your CustomerAddress to an existing Customer on an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <param name="customerAddress">Your CustomerAddress which you want to post</param>
        /// <returns></returns>
        public static CustomerAddress PostCustomerAddress(string caseId, CustomerAddress customerAddress)
        {
            string uri = string.Format(Constants.UriCustomerAddressPost, BaseUrl, caseId);

            CustomerAddress response = PerformHttpCall<CustomerAddress>(uri, HttpMethod.Post, customerAddress, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update a specific CustomerAddress on a Case which already contains a CustomerAddresses
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="customerAddress">The CustomerAddress you want to update the existing CustomerAddress to</param>
        /// <param name="customerAddressId">The id of the CustomerAddress you want to update</param>
        /// <returns></returns>
        public static CustomerAddress UpdateCustomerAddress(string caseId, CustomerAddress customerAddress, Guid customerAddressId)
        {
            string uri = string.Format(Constants.UriCustomerAddressUpdate, BaseUrl, caseId, customerAddressId);

            CustomerAddress response = PerformHttpCall<CustomerAddress>(uri, HttpMethod.Put, customerAddress, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific customerAddress from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <param name="customerAddressId">The Id of the CustomerAddress you want to get</param>
        /// <returns></returns>
        public static CustomerAddress GetCustomerAddress(string caseId, Guid customerAddressId)
        {
            string uri = string.Format(Constants.UriCustomerAddressGet, BaseUrl, caseId, customerAddressId);

            CustomerAddress response = PerformHttpCall<CustomerAddress>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Customer on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer  which you have already posted</param>
        /// <returns></returns>
        public static IList<CustomerAddress> GetCustomerAddresses(string caseId)
        {
            string uri = string.Format(Constants.UriCustomerAddressesGet, BaseUrl, caseId);

            IList<CustomerAddress> response = PerformHttpCall<IList<CustomerAddress>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your Customer Email to an existing Customer on an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <param name="email">Your Customer Email which you want to post</param>
        /// <returns></returns>
        public static Email PostEmail(string caseId, Email email)
        {
            string uri = string.Format(Constants.UriCustomerEmailPost, BaseUrl, caseId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Post, email, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update a specific Customer Email on a Case which already contains a Email
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="email">The Customer Email you want to update the existing Email to</param>
        /// <param name="emailId">The Id of the Email you want to update</param>
        /// <returns></returns>
        public static Email UpdateEmail(string caseId, Email email, Guid emailId)
        {
            string uri = string.Format(Constants.UriCustomerEmailUpdate, BaseUrl, caseId, emailId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Put, email, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific Customer Email from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <param name="emailId">The Id of the Email you want to get</param>
        /// <returns></returns>
        public static Email GetEmail(string caseId, Guid emailId)
        {
            string uri = string.Format(Constants.UriCustomerEmailGet, BaseUrl, caseId, emailId);

            Email response = PerformHttpCall<Email>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get all the Customer Emails from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <returns></returns>
        public static IList<Email> GetEmails(string caseId)
        {
            string uri = string.Format(Constants.UriCustomerEmailsGet, BaseUrl, caseId);

            IList<Email> response = PerformHttpCall<IList<Email>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your Payment to an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="payment">Your Payment which you want to post</param>
        /// <returns></returns>
        public static Payment PostPayment(string caseId, Payment payment)
        {
            string uri = string.Format(Constants.UriPaymentPost, BaseUrl, caseId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Post, payment, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update a specific Payment on a Case which already contains a Payments
        /// </summary><param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="payment">The Payment you want to update the existing Payment to</param>
        /// <param name="paymentId">The id of the Payment you want to update</param>
        /// <returns></returns>
        public static Payment UpdatePayment(string caseId, Payment payment, Guid paymentId)
        {
            string uri = string.Format(Constants.UriPaymentUpdate, BaseUrl, caseId, paymentId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Put, payment, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific Payment from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="paymentId">The Id of the Payment you want to get</param>
        /// <returns></returns>
        public static Payment GetPayment(string caseId, Guid paymentId)
        {
            string uri = string.Format(Constants.UriPaymentGet, BaseUrl, caseId, paymentId);

            Payment response = PerformHttpCall<Payment>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get all the Payments from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <returns></returns>
        public static IList<Payment> GetPayments(string caseId)
        {
            string uri = string.Format(Constants.UriPaymentsGet, BaseUrl, caseId);

            IList<Payment> response = PerformHttpCall<IList<Payment>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your TransactionAddress to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <param name="transactionAddress">Your TransactionAddress which you want to post</param>
        /// <returns></returns>
        public static TransactionAddress PostTransactionAddress(string caseId, TransactionAddress transactionAddress)
        {
            string uri = string.Format(Constants.UriTransactionAddressPost, BaseUrl, caseId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Post, transactionAddress, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionAddress on a Case which already contains a TransactionAddress
        /// </summary><param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="transactionAddress">The TransactionAddress you want to update the existing TransactionAddress to</param>
        /// <param name="transactionAddressId">The id of the TransactionAddress you want to update</param>
        /// <returns></returns>
        public static TransactionAddress UpdateTransactionAddress(string caseId, TransactionAddress transactionAddress, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.UriTransactionAddressUpdate, BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Put, transactionAddress, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionAddress from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <param name="transactionAddressId">The Id of the TransactionAddress you want to get</param>
        /// <returns></returns>
        public static TransactionAddress GetTransactionAddress(string caseId, Guid transactionAddressId)
        {
            string uri = string.Format(Constants.UriTransactionAddressGet, BaseUrl, caseId, transactionAddressId);

            TransactionAddress response = PerformHttpCall<TransactionAddress>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a all the addresses from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static IList<TransactionAddress> GetTransactionAddresses(string caseId)
        {
            string uri = string.Format(Constants.UriTransactionAddressesGet, BaseUrl, caseId);

            IList<TransactionAddress> response = PerformHttpCall<IList<TransactionAddress>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your TransactionItem to an existing Transaction on an existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <param name="transactionItem">Your TransactionItem which you want to post</param>
        /// <returns></returns>
        public static TransactionItem PostTransactionItem(string caseId, TransactionItem transactionItem)
        {
            string uri = string.Format(Constants.UriTransactionItemPost, BaseUrl, caseId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Post, transactionItem, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Update a specific TransactionItem on a Case which already contains a TransactionItem
        /// </summary>
        /// <param name="caseId">The Case Id of a Case which you have already posted</param>
        /// <param name="transactionItem">The TransactionAddress you want to update the existing TransactionItem to</param>
        /// <param name="transactionItemId">The id of the TransactionItem you want to update</param>
        /// <returns></returns>
        public static TransactionItem UpdateTransactionItem(string caseId, TransactionItem transactionItem, Guid transactionItemId)
        {
            string uri = string.Format(Constants.UriTransactionItemUpdate, BaseUrl, caseId, transactionItemId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Put, transactionItem, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a specific TransactionItem from a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Customer which you have already posted</param>
        /// <param name="transactionItemId">The Id of the TransactionItem you want to get</param>
        /// <returns></returns>
        public static TransactionItem GetTransactionItem(string caseId, Guid transactionItemId)
        {
            string uri = string.Format(Constants.UriTransactionItemGet, BaseUrl, caseId, transactionItemId);

            TransactionItem response = PerformHttpCall<TransactionItem>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Get a all the TransactionItems from a Transaction on a Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case with the Transaction which you have already posted</param>
        /// <returns></returns>
        public static IList<TransactionItem> GetTransactionItems(string caseId)
        {
            string uri = string.Format(Constants.UriTransactionItemsGet, BaseUrl, caseId);

            IList<TransactionItem> response = PerformHttpCall<IList<TransactionItem>>(uri, HttpMethod.Get, null, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// Post your KBAResult existing Case
        /// </summary>
        /// <param name="caseId">The Case Id of a Case</param>
        /// <param name="kbaResult">Your KBA Result which you want to post</param>
        /// <returns></returns>
        public static KBAResult PostKBAResult(string caseId, KBAResult kbaResult)
        {
            string uri = string.Format(Constants.UriKBAResultPost, BaseUrl, caseId);

            KBAResult response = PerformHttpCall<KBAResult>(uri, HttpMethod.Post, kbaResult, true, HttpRequestTimeout);

            return response;
        }

        /// <summary>
        /// This method synchronously performs the Http Request to the TrustevClient API
        /// </summary>
        /// <typeparam name="T">The Type of the return object</typeparam>
        /// <param name="uri">The HttpMethod Uri</param>
        /// <param name="method">The Http Method</param>
        /// <param name="entity">The relevant entity</param>
        /// <param name="isAuthenticationNeeded">Does this api call require the X-Authorization header</param>
        /// <param name="requestTimeout">The timeout value of this http request in milliseconds</param>
        /// <returns></returns>
        private static T PerformHttpCall<T>(string uri, HttpMethod method, object entity, bool isAuthenticationNeeded = true, int requestTimeout = 15000)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            DefaultContractResolver dcr = new PrivateSetterContractResolver();
            jss.ContractResolver = dcr;

            try
            {
                WebRequest request = WebRequest.Create(uri);

                request.Method = method.ToString();

                request.ContentType = "application/json";

                if (isAuthenticationNeeded)
                {
                    if (uri.Contains("/session"))
                    {
                        if(string.IsNullOrEmpty(PublicKey))
                            throw new TrustevGeneralException("You need to set your public key if you want to post a Session. This can be done via the SetUp method");

                        request.Headers.Add("X-PublicKey", PublicKey);
                    }
                    else
                        request.Headers.Add("X-Authorization", string.Format("{0} {1}", UserName, GetToken()));
                }

                request.Timeout = requestTimeout;

                if (method != HttpMethod.Get)
                {
                    string json = string.Empty;

                    if (entity != null && entity.GetType() != typeof(string))
                    {
                        json = JsonConvert.SerializeObject(entity, jss);
                    }
                    else
                    {
                        json = (string)entity;
                    }

                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    request.ContentLength = byteArray.Length;

                    Stream requestDataStream = request.GetRequestStream();

                    requestDataStream.Write(byteArray, 0, byteArray.Length);

                    requestDataStream.Close();
                }

                WebResponse response = request.GetResponse();

                Stream responseDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseDataStream);

                string resultstring = reader.ReadToEnd();

                reader.Close();
                responseDataStream.Close();
                response.Close();

                return JsonConvert.DeserializeObject<T>(resultstring, jss);
            }
            catch (WebException ex)
            {
                Stream responseDataStream = ex.Response.GetResponseStream();

                StreamReader reader = new StreamReader(responseDataStream);

                string errorMessage = reader.ReadToEnd();

                reader.Close();
                responseDataStream.Close();
                ex.Response.Close();

                throw new TrustevHttpException(((HttpWebResponse)ex.Response).StatusCode, errorMessage);
            }
        }

        #region Private Methods

        private static string GetToken()
        {
            string apiToken = "";

            CheckCredentials();

            DateTime currentTime = DateTime.UtcNow;

            TokenRequest requestObject = new TokenRequest()
            {
                UserName = UserName,
                PasswordHash = PasswordHashHelper(Password, Secret, currentTime),
                UserNameHash = UserNameHashHelper(UserName, Secret, currentTime),
                TimeStamp = currentTime.ToString("o")
            };

            string requestJson = JsonConvert.SerializeObject(requestObject);

            string uri = string.Format("{0}/token", BaseUrl);

            TokenResponse response = PerformHttpCall<TokenResponse>(uri, HttpMethod.Post, requestJson, false, HttpRequestTimeout);

            apiToken = response.APIToken;

            return apiToken;
        }

        /// <summary>
        /// Check that the user has set the TrustevClient Credentials correctly
        /// </summary>
        private static void CheckCredentials()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Secret) || string.IsNullOrEmpty(Password))
            {
                throw new TrustevGeneralException("You have not set your TrustevClient credentials correctly. You need to set these by calling the SetUp method on the TrustevClient Class providing your UserName, Password and Secret as the paramters before you can access the TrustevClient API");
            }
        }

        /// <summary>
        /// Has password, secret and timestamp for GetToken request
        /// </summary>
        /// <param name="password">Your Trustev Password</param>
        /// <param name="sharedsecret">Your Trustev Secret</param>
        /// <param name="timestamp">The current UTC timestamp</param>
        /// <returns></returns>
        private static string PasswordHashHelper(string password, string sharedsecret, DateTime timestamp)
        {
            sharedsecret = sharedsecret.Replace("\"", string.Empty);
            password = password.Replace("\"", string.Empty);
            return Create256Hash(Create256Hash(timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "." + password) + "." + sharedsecret);
        }

        /// <summary>
        /// Has username, secret and timestamp for GetToken request
        /// </summary>
        /// <param name="username">Your Trustev UserName</param>
        /// <param name="sharedsecret">Your Trustev Secret</param>
        /// <param name="timestamp">The current UTC timestamp</param>
        /// <returns></returns>
        private static string UserNameHashHelper(string username, string sharedsecret, DateTime timestamp)
        {
            sharedsecret = sharedsecret.Replace("\"", string.Empty);
            username = username.Replace("\"", string.Empty);
            return Create256Hash(Create256Hash(timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "." + username) + "." + sharedsecret);
        }

        private static string Create256Hash(string toHash)
        {
            HashAlgorithm sha = new SHA256Managed();

            byte[] tohashBytes = Encoding.UTF8.GetBytes(toHash);
            byte[] resultBytes = sha.ComputeHash(tohashBytes);

            return HexEncode(resultBytes);
        }

        private static string HexEncode(byte[] data)
        {
            string result = string.Empty;
            foreach (byte b in data)
            {
                result += b.ToString("X2");
            }

            result = result.ToLower();

            return result;
        }

        /// <summary>
        /// TrustevClient token response object
        /// </summary>
        private class TokenResponse
        {
            public string APIToken { get; set; }

            public DateTime ExpireAt { get; set; }
        }

        /// <summary>
        /// TrustevClient token request object
        /// </summary>
        private class TokenRequest
        {
            public string UserName { get; set; }

            public string PasswordHash { get; set; }

            public string UserNameHash { get; set; }

            public string TimeStamp { get; set; }
        }

        private class PrivateSetterContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);

                if (!prop.Writable)
                {
                    var property = member as PropertyInfo;
                    if (property != null)
                    {
                        var hasPrivateSetter = property.GetSetMethod(true) != null;
                        prop.Writable = hasPrivateSetter;
                    }
                }

                return prop;
            }
        }
        #endregion
    }
}
